namespace DeckBuilderService.Banlist
{
    public interface IBanlist
    {
        /// <summary>
        ///     Builds the banlist.
        /// </summary>
        public void BuildBanlist();

        /// <summary>
        ///     Checks if the card is restricted.
        /// </summary>
        /// <returns></returns>
        public bool IsRestricted();
    }
}
