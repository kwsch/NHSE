using System;

namespace NHSE.Core
{
    /// <summary>
    /// Metadata for dealing with language codes
    /// </summary>
    public static class GameLanguage
    {
        public const string DefaultLanguage = "en"; // English
        public static int DefaultLanguageIndex => Array.IndexOf(LanguageCodes, DefaultLanguage);
        public static string Language2Char(int lang) => lang > LanguageCodes.Length ? DefaultLanguage : LanguageCodes[lang];

        public static int LanguageCount => LanguageCodes.Length;

        public static int GetLanguageIndex(string lang)
        {
            int l = Array.IndexOf(LanguageCodes, lang);
            return l < 0 ? DefaultLanguageIndex : l;
        }

        /// <summary>
        /// Language codes supported for loading string resources
        /// </summary>
        private static readonly string[] LanguageCodes = { "en", "jp", "de", "es", "fr", "it", "ko", "zhs", "zht" };

        public static string[] GetStrings(string ident, string lang, string type = "text")
        {
            string[] data = ResourceUtil.GetStringList(ident, lang, type);
            if (data.Length == 0)
                data = ResourceUtil.GetStringList(ident, DefaultLanguage, type);

            return data;
        }
    }
}