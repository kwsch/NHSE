using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.WinForms.Properties;

namespace NHSE.WinForms
{
#if DEBUG
    public static class DevUtil
    {
        private static readonly string[] Languages = { "jp", "de", "es", "fr", "it", "ko", "zhs", "zht" };
        private const string DefaultLanguage = GameLanguage.DefaultLanguage;

        public static bool IsUpdatingTranslations { get; private set; }

        /// <summary>
        /// Call this to update all translatable resources (Program Messages, Legality Text, Program GUI)
        /// </summary>
        public static void UpdateAll()
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "Update translation files with current values?"))
                return;
            IsUpdatingTranslations = true;
            DumpStringsMessage();
            UpdateTranslations();
            UpdateInternalNameTranslations();
            IsUpdatingTranslations = false;
        }

        private static void UpdateTranslations()
        {
            WinFormsTranslator.LoadSpecialForms = LoadSpecialForms;
            WinFormsTranslator.SetRemovalMode(false); // add mode
            WinFormsTranslator.LoadAllForms(LoadBanlist); // populate with every possible control
            WinFormsTranslator.UpdateAll(DefaultLanguage, Languages); // propagate to others
            WinFormsTranslator.DumpAll(Banlist); // dump current to file
            WinFormsTranslator.SetRemovalMode(); // remove used keys, don't add any
            WinFormsTranslator.LoadAllForms(LoadBanlist); // de-populate
            WinFormsTranslator.RemoveAll(DefaultLanguage, PurgeBanlist); // remove all lines from above generated files that still remain

            // Move translated files from the debug exe loc to their project location
            var files = Directory.GetFiles(Application.StartupPath);
            var dir = GetResourcePath().Replace("NHSE.Core", "NHSE.WinForms");
            foreach (var f in files)
            {
                var fn = Path.GetFileName(f);
                if (!fn.EndsWith(".txt"))
                    continue;
                if (!fn.StartsWith("lang_"))
                    continue;

                var loc = Path.Combine(dir, fn);
                if (File.Exists(loc))
                    File.Delete(loc);
                File.Move(f, loc);
            }

            Application.Exit();
        }

        private static void LoadSpecialForms()
        {
            // For forms that require more complete initialization (dynamically added user controls)
            var path = Settings.Default.LastFilePath;
            var sav = new HorizonSave(path);
            using var editor = new Editor(sav);
            using var so = new SingleObjectEditor<object>(new object(), PropertySort.NoSort, false);
        }

        private static readonly string[] LoadBanlist =
        {
            nameof(SettingsEditor),
            nameof(Editor), // special handling above
        };

        private static readonly string[] Banlist =
        {
            "Editor=NHSE", // Program Title
            "InternalName=",
            "ExternalName=",
            "AcreEditor.L_X",
            "AcreEditor.L_Y",
            "L_Coordinates",
            "L_PatternName=",
            "L_RemakeBody=",
            "L_RemakeFabric=",
            "AchievementEditor.L_Threshold",
        };

        private static readonly string[] PurgeBanlist =
        {
            nameof(SettingsEditor),
        };

        private static void UpdateInternalNameTranslations()
        {
            var langs = new[] { DefaultLanguage }.Concat(Languages);
            var available = new[]
            {
                LifeSupportAchievement.List.Values.Select(z => z.Name),
                EventFlagPlayer.List.Values.Select(z => z.Name),
                EventFlagLand.List.Values.Select(z => z.Name),
                EventFlagVillager.List.Values.Select(z => z.Name),
            }.SelectMany(z => z);

            var translatables = new HashSet<string>(available);
            foreach (var lang in langs)
            {
                var str = GameInfo.GetStrings(lang);
                var dict = str.InternalNameTranslation;

                var oldKeys = dict
                    .Where(kvp => translatables.Contains(kvp.Key));
                var newKeys = translatables
                    .Where(key => !dict.ContainsKey(key))
                    .Select(z => new KeyValuePair<string, string>(z, z));

                var allKeys = oldKeys.Concat(newKeys);

                var newDict = allKeys.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                var result = newDict.Select(z => $"{z.Key}={z.Value}");
                var dir = GetResourcePath();
                var location = GetFileLocationInText("internal", dir, lang);
                File.WriteAllLines(location, result);
            }
        }

        private static void DumpStringsMessage() => DumpStrings(typeof(MessageStrings));

        private static void DumpStrings(Type t)
        {
            var langs = new[] { DefaultLanguage }.Concat(Languages);
            var dir = GetResourcePath();
            foreach (var lang in langs)
            {
                TranslationUtil.SetLocalization(t, lang);
                var entries = TranslationUtil.GetLocalization(t);
                var location = GetFileLocationInText(t.Name, dir, lang);
                File.WriteAllLines(location, entries);
                TranslationUtil.SetLocalization(t, DefaultLanguage);
            }
        }

        private static string GetFileLocationInText(string fileType, string dir, string lang)
        {
            var path = Path.Combine(dir, lang);
            if (!Directory.Exists(path))
                path = Path.Combine(dir, "other");

            var fn = $"{fileType}_{lang}.txt";
            return Path.Combine(path, fn);
        }

        private static string GetResourcePath()
        {
            var path = Application.StartupPath;
            const string projname = "NHSE\\";
            var pos = path.LastIndexOf(projname, StringComparison.Ordinal);
            var str = path.Substring(0, pos + projname.Length);
            return Path.Combine(str, "NHSE.Core", "Resources", "text");
        }
    }
#endif
}
