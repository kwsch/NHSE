using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
#if DEBUG
    public static class DevUtil
    {
        private static readonly string[] Languages = { "jp", "zh" };
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
            IsUpdatingTranslations = false;
        }

        private static void UpdateTranslations()
        {
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

        private static readonly string[] LoadBanlist =
        {
            nameof(SettingsEditor),
        };

        private static readonly string[] Banlist =
        {
            "Editor=NHSE", // Program Title
            "InternalName=",
            "ExternalName=",
            "AcreEditor.L_X",
            "AcreEditor.L_Y",
            "L_Coordinates",
        };

        private static readonly string[] PurgeBanlist =
        {
            nameof(SettingsEditor),
        };

        private static void DumpStringsMessage() => DumpStrings(typeof(MessageStrings));

        private static void DumpStrings(Type t)
        {
            var dir = GetResourcePath();
            var langs = new[] { DefaultLanguage }.Concat(Languages);
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
