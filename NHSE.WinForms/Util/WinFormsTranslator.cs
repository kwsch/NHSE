﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public static class WinFormsTranslator
    {
        private static readonly Dictionary<string, TranslationContext> Context = new();
        internal static void TranslateInterface(this Control form, string lang) => TranslateForm(form, GetContext(lang));

        private static string GetTranslationFileNameInternal(string lang) => $"lang_{lang}";
        private static string GetTranslationFileNameExternal(string lang) => $"lang_{lang}.txt";

        internal static Action LoadSpecialForms = () => { };

        private static TranslationContext GetContext(string lang)
        {
            if (Context.TryGetValue(lang, out var context))
                return context;

            var lines = GetTranslationFile(lang);
            Context.Add(lang, context = new TranslationContext(lines));
            return context;
        }

        private static void TranslateForm(Control form, TranslationContext context)
        {
            form.SuspendLayout();
            var formname = form.Name;
            // Translate Title
            form.Text = context.GetTranslatedText(formname, form.Text);
            var translatable = GetTranslatableControls(form);
            foreach (var c in translatable)
            {
                if (c is Control r)
                {
                    var current = r.Text;
                    var updated = context.GetTranslatedText($"{formname}.{r.Name}", current);
                    if (!ReferenceEquals(current, updated))
                        r.Text = updated;
                }
                else if (c is ToolStripItem t)
                {
                    var current = t.Text;
                    var updated = context.GetTranslatedText($"{formname}.{t.Name}", current);
                    if (!ReferenceEquals(current, updated))
                        t.Text = updated;
                }
            }
            form.ResumeLayout();
        }

        private static IEnumerable<string> GetTranslationFile(string lang)
        {
            var file = GetTranslationFileNameInternal(lang);
            // Check to see if a the translation file exists in the same folder as the executable
            string externalLangPath = GetTranslationFileNameExternal(file);
            if (File.Exists(externalLangPath))
            {
                try
                {
                    return File.ReadAllLines(externalLangPath);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception e)
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    /* In use? Just return the internal resource. */
                    Console.WriteLine(e.Message);
                }
            }

            if (ResourceUtil.IsStringListCached(file, out var result))
                return result;
            var obj = Properties.Resources.ResourceManager.GetObject(file);
            if (obj is not string txt)
                return Array.Empty<string>();
            return ResourceUtil.LoadStringList(file, txt);
        }

        private static IEnumerable<object> GetTranslatableControls(Control f)
        {
            foreach (var z in f.GetChildrenOfType<Control>())
            {
                switch (z)
                {
                    case ToolStrip menu:
                        foreach (var obj in GetToolStripMenuItems(menu))
                            yield return obj;

                        break;
                    default:
                        if (string.IsNullOrWhiteSpace(z.Name))
                            break;

                        if (z.ContextMenuStrip != null) // control has attached menustrip
                        {
                            foreach (var obj in GetToolStripMenuItems(z.ContextMenuStrip))
                                yield return obj;
                        }

                        if (z is ListControl || z is TextBoxBase || z is LinkLabel || z is NumericUpDown || z is ContainerControl)
                            break; // undesirable to modify, ignore

                        if (!string.IsNullOrWhiteSpace(z.Text))
                            yield return z;
                        break;
                }
            }
        }

        private static IEnumerable<T> GetChildrenOfType<T>(this Control control) where T : class
        {
            foreach (var child in control.Controls.OfType<Control>())
            {
                if (child is T childOfT)
                    yield return childOfT;

                if (!child.HasChildren)
                    continue;

                foreach (var descendant in GetChildrenOfType<T>(child))
                    yield return descendant;
            }
        }

        private static IEnumerable<object> GetToolStripMenuItems(ToolStrip menu)
        {
            foreach (var i in menu.Items.OfType<ToolStripMenuItem>())
            {
                if (!string.IsNullOrWhiteSpace(i.Text))
                    yield return i;
                foreach (var sub in GetToolsStripDropDownItems(i).Where(z => !string.IsNullOrWhiteSpace(z.Text)))
                    yield return sub;
            }
        }

        private static IEnumerable<ToolStripMenuItem> GetToolsStripDropDownItems(ToolStripDropDownItem item)
        {
            foreach (var dropDownItem in item.DropDownItems.OfType<ToolStripMenuItem>())
            {
                yield return dropDownItem;
                if (!dropDownItem.HasDropDownItems) continue;
                foreach (ToolStripMenuItem subItem in GetToolsStripDropDownItems(dropDownItem))
                    yield return subItem;
            }
        }

        public static void UpdateAll(string baseLanguage, IEnumerable<string> others)
        {
            var basecontext = GetContext(baseLanguage);
            foreach (var lang in others)
            {
                var c = GetContext(lang);
                c.UpdateFrom(basecontext);
            }
        }

        public static void DumpAll(params string[] banlist)
        {
            var results = Context.Select(z => new { Lang = z.Key, Lines = z.Value.Write() });
            foreach (var c in results)
            {
                var lang = c.Lang;
                var fn = GetTranslationFileNameExternal(lang);
                var lines = c.Lines;
                var result = lines.Where(z => !banlist.Any(z.Contains));
                File.WriteAllLines(fn, result);
            }
        }

        public static void LoadAllForms(params string[] banlist)
        {
            LoadSpecialForms();

            var q = from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    where t.BaseType == typeof(Form) && !banlist.Contains(t.Name)
                    select t;
            foreach (var t in q)
            {
                var constructors = t.GetConstructors();
                if (constructors.Length == 0)
                {
                    Console.WriteLine($"No constructors: {t.Name}");
                    continue;
                }
                var argCount = constructors[0].GetParameters().Length;
                try
                {
                    var _ = Activator.CreateInstance(t, new object[argCount]);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch
#pragma warning restore CA1031 // Do not catch general exception types
                {
                    // ignored
                }
            }
        }

        public static void SetRemovalMode(bool status = true)
        {
            foreach (TranslationContext c in Context.Values)
            {
                c.RemoveUsedKeys = status;
                c.AddNew = !status;
            }
        }

        public static void RemoveAll(string defaultLanguage, params string[] banlist)
        {
            var badKeys = Context[defaultLanguage];
            var split = badKeys.Write().Select(z => z.Split(TranslationContext.Separator)[0])
                .Where(l => !banlist.Any(l.StartsWith)).ToArray();
            foreach (var c in Context)
            {
                var lang = c.Key;
                var fn = GetTranslationFileNameExternal(lang);
                var lines = File.ReadAllLines(fn);
                var result = lines.Where(l => !split.Any(s => l.StartsWith(s + TranslationContext.Separator)));
                File.WriteAllLines(fn, result);
            }
        }
    }

    public sealed class TranslationContext
    {
        public bool AddNew { private get; set; }
        public bool RemoveUsedKeys { private get; set; }
        public const char Separator = '=';
        private readonly Dictionary<string, string> Translation = new();

        public TranslationContext(IEnumerable<string> content, char separator = Separator)
        {
            var entries = GetContent(content, separator);
            foreach (var kvp in entries.Where(z => !Translation.ContainsKey(z.Key)))
                Translation.Add(kvp.Key, kvp.Value);
        }

        private static IEnumerable<KeyValuePair<string, string>> GetContent(IEnumerable<string> content, char separator)
        {
            foreach (var line in content)
            {
                var index = line.IndexOf(separator);
                if (index < 0)
                    continue;
                var key = line.Substring(0, index);
                var value = line.Substring(index + 1);
                yield return new KeyValuePair<string, string>(key, value);
            }
        }

        public string GetTranslatedText(string val, string fallback)
        {
            if (RemoveUsedKeys)
                Translation.Remove(val);

            if (Translation.TryGetValue(val, out var translated))
                return translated;

            if (AddNew)
                Translation.Add(val, fallback);
            return fallback;
        }

        public IEnumerable<string> Write(char separator = Separator)
        {
            return Translation.Select(z => $"{z.Key}{separator}{z.Value}").OrderBy(z => z.Contains(".")).ThenBy(z => z);
        }

        public void UpdateFrom(TranslationContext other)
        {
            bool oldAdd = AddNew;
            AddNew = true;
            foreach (var kvp in other.Translation)
                GetTranslatedText(kvp.Key, kvp.Value);
            AddNew = oldAdd;
        }

        public void RemoveKeys(TranslationContext other)
        {
            foreach (var kvp in other.Translation)
                Translation.Remove(kvp.Key);
        }
    }
}
