using System;

namespace DeckBuilderService.Models.Data
{
    public class SetReleases
    {
        /// <summary>
        ///     The key value by DynamoDB.
        /// </summary>
        public int DynamoKey { get; private set; }

        /// <summary>
        ///     This is the Konami Code given to us.
        /// </summary>
        public string SetCode { get; set; }

        /// <summary>
        ///     The Konami release date for a set.
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }
}
