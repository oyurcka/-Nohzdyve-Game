namespace Model.Menu
{
    /// <summary>
    /// Статический класс с информацией об игре
    /// </summary>
    public static class About
    {
        /// <summary>
        /// Информация об игре
        /// </summary>
        public readonly static string AboutText = Properties.Resources.About + '\n' + Properties.Resources.Credits +
                                                  '\n' + Properties.Resources.LeftInstructions + 
                                                  '\n' + Properties.Resources.RightInstructions +
                                                  '\n' + Properties.Resources.EscapeInstructions;
    }
}