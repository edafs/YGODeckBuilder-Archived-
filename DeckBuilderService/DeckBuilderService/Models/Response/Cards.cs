namespace DeckBuilderService.Models.Response
{
    /// <summary>
    ///     A response model object for the cards.
    /// </summary>
    public class MonsterCard
    {
        /// <summary>
        ///     Unique identifier for the card.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Name of the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Image URL for the card.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        ///     Image URL for the card thumbnail.
        /// </summary>
        public string Thumbnail { get; set; }
    }
}
