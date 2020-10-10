using System;

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
        public string SetName { get; set; }

        /// <summary>
        ///     The set code.
        /// </summary>
        public string SetCode { get; set; }

        /// <summary>
        ///     The number of cards in a set.
        /// </summary>
        public int CardCount { get; set; }

        /// <summary>
        ///     The release date of the TCG.
        /// </summary>
        public DateTime TcgDate { get; set; }
    }
}
