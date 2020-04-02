namespace NHSE.Core
{
    /// <summary>
    /// Global repository for game strings; initialized to a specified language.
    /// </summary>
    public static class GameInfo
    {
        private static readonly GameStrings?[] Languages = new GameStrings[GameLanguage.LanguageCount];

        public static string CurrentLanguage { get; set; } = GameLanguage.DefaultLanguage;
        public static GameStrings Strings { get; set; } = GetStrings(CurrentLanguage);

        /// <summary>
        /// Gets the Game Strings for a specific language.
        /// </summary>
        /// <param name="lang">2 character language ID</param>
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