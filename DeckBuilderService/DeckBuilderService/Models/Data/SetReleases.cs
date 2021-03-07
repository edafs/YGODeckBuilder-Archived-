using Amazon.DynamoDBv2.DataModel;

namespace DeckBuilderService.Models.Data
{
    [DynamoDBTable("YGO_SetCatalog")]
    public class SetReleases
    {
        /// <summary>
        ///     This is the Konami Code given to us.
        /// </summary>
        [DynamoDBHashKey]
        public string SetCode { get; set; }

        /// <summary>
        ///     The Konami release date for a set.
        /// </summary>
        /// <remarks>
        ///     Amazon recommends store dates as ISO-8601 strings.
        /// </remarks>
        public string ReleaseDate { get; set; }
    }
}
