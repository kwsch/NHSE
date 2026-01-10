using NHSE.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace NHSE.WinForms;

public static class WinFormsTranslator
{
    private static readonly Dictionary<string, TranslationContext> Context = [];
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
                var current = t.Text!;
                var updated = context.GetTranslatedText($"{formname}.{t.Name}", current);
                if (!ReferenceEquals(current, updated))
                    t.Text = updated;
            }
        }
        form.ResumeLayout();
    }

    private static string[] GetTranslationFile(string lang)
    {
        var file = GetTranslationFileNameInternal(lang);
        // Check to see if the translation file exists in the same folder as the executable
        string externalLangPath = GetTranslationFileNameExternal(file);
        if (File.Exists(externalLangPath))
        {
            try
            {
                return File.ReadAllLines(externalLangPath);
            }
            catch (Exception e)
            {
                /* In use? Just return the internal resource. */
                Console.WriteLine(e.Message);
            }
        }

        if (ResourceUtil.IsStringListCached(file, out var result))
            return result;
        var obj = Properties.Resources.ResourceManager.GetObject(file);
        if (obj is not string txt)
            return [];
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

                    if (z.ContextMenuStrip is not null) // control has attached MenuStrip
                    {
                        foreach (var obj in GetToolStripMenuItems(z.ContextMenuStrip))
                            yield return obj;
                    }

                    if (Application.IsDarkModeEnabled) // NET10
                        ReformatDark(z);

                    if (z is ListControl or TextBoxBase or LinkLabel or NumericUpDown or ContainerControl)
                        break; // undesirable to modify, ignore

                    if (z is DataGridView { ColumnHeadersVisible: true } dgv)
                    {
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col.Visible && !string.IsNullOrWhiteSpace(col.HeaderText))
                                yield return col;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(z.Text))
                        yield return z;
                    break;
            }
        }
    }

    private static void ReformatDark(Control z)
    {
        if (z is TabControl tc)
        {
            foreach (TabPage tab in tc.TabPages)
                tab.UseVisualStyleBackColor = false;
        }
        else if (z is DataGridView dg)
        {
            dg.EnableHeadersVisualStyles = false;
            dg.BorderStyle = BorderStyle.None;
        }
        else if (z is ComboBox cb)
        {
            cb.FlatStyle = FlatStyle.Popup;
        }
        else if (z is ListBox lb)
        {
            lb.BorderStyle = BorderStyle.None;
        }
        else if (z is TextBoxBase tb)
        {
            tb.BorderStyle = BorderStyle.FixedSingle;
        }
        else if (z is NumericUpDown nud)
        {
            nud.BorderStyle = BorderStyle.FixedSingle;
        }
        else if (z is GroupBox gb)
        {
            gb.FlatStyle = FlatStyle.Popup;
        }
        else if (z is RichTextBox rtb)
        {
            rtb.BorderStyle = BorderStyle.None;
        }
        else if (z is ButtonBase b)
        {
            b.FlatStyle = FlatStyle.Popup;
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

            foreach (var descendant in child.GetChildrenOfType<T>())
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

    private static bool IsBannedStartsWith(ReadOnlySpan<char> line, ReadOnlySpan<string> banlist)
    {
        foreach (var banned in banlist)
        {
            if (line.StartsWith(banned, StringComparison.Ordinal))
                return true;
        }
        return false;
    }

    public static void LoadAllForms(IEnumerable<Type> types, ReadOnlySpan<string> banlist)
    {
        foreach (var t in types)
        {
            if (!typeof(Form).IsAssignableFrom(t) || IsBannedStartsWith(t.Name, banlist))
                continue;

            var constructors = t.GetConstructors();
            if (constructors.Length == 0)
            { System.Diagnostics.Debug.WriteLine($"No constructors: {t.Name}"); continue; }
            var argCount = constructors[0].GetParameters().Length;
            try
            {
                var form = (Form?)Activator.CreateInstance(t, new object[argCount]);
                form?.Dispose();
            }
            // This is a debug utility method, will always be logging. Shouldn't ever fail.
            catch (TargetInvocationException)
            {
                // Don't care; forms will sometimes fail to load.
            }
            catch
            {
                System.Diagnostics.Debug.Write($"Failed to create a new form {t}");
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
    private readonly Dictionary<string, string> Translation = [];

    public TranslationContext(string[] content, char separator = Separator)
    {
        var entries = GetContent(content, separator);
        foreach (var kvp in entries.Where(z => !Translation.ContainsKey(z.Key)))
            Translation.Add(kvp.Key, kvp.Value);
    }

    private static IEnumerable<KeyValuePair<string, string>> GetContent(string[] content, char separator)
    {
        foreach (var line in content)
        {
            var index = line.IndexOf(separator);
            if (index < 0)
                continue;
            var key = line[..index];
            var value = line[(index + 1)..];
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
        return Translation.Select(z => $"{z.Key}{separator}{z.Value}").OrderBy(z => z.Contains('.')).ThenBy(z => z);
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