using System.Collections.Generic;

namespace NHSE.Core
{
    public static class GameInfo
    {
        private static readonly GameStrings[] Languages = new GameStrings[GameLanguage.LanguageCount];

        public static string CurrentLanguage { get; set; } = GameLanguage.DefaultLanguage;
        public static readonly IReadOnlyList<string> GenderSymbolUnicode = new[] { "♂", "♀", "-" };
        public static readonly IReadOnlyList<string> GenderSymbolASCII = new[] { "M", "F", "-" };
        public static GameStrings Strings { get; set; } = GetStrings(CurrentLanguage);

        public static GameStrings GetStrings(string lang)
        {
            int index = GameLanguage.GetLanguageIndex(lang);
            return GetStrings(index);
        }

        public static GameStrings GetStrings(int index)
        {
            return Languages[index] ??= new GameStrings(GameLanguage.Language2Char(index));
        }
    }
}