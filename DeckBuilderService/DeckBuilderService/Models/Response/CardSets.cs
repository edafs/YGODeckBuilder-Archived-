namespace DeckBuilderService.Models.Response
{
    /// <summary>
    ///     Response models for the card sets.
    /// </summary>
    /// <remarks>
    ///     https://db.ygoprodeck.com/api/v7/cardsets.php
    /// </remarks>
    public class CardSets
    {
        /// <summary>
        ///     The name of the set.
        /// </summary>
        public string set_name { get; set; }

        /// <summary>
        ///     The set code.
        /// </summary>
        public string set_code { get; set; }

        /// <summary>
        ///     The number of cards in a set.
        /// </summary>
        public int num_of_cards { get; set; }

        /// <summary>
        ///     The release date of the TCG.
        /// </summary>
        public string tcg_date { get; set; }
    }
}
