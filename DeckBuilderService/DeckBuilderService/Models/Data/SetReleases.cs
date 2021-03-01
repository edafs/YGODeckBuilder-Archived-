using Amazon.DynamoDBv2.DataModel;

namespace DeckBuilderService.Models.Data
{
    [DynamoDBTable("YGO_SetCatalog")]
    public class SetReleases
    {
        /// <summary>
        ///     The key value by DynamoDB.
        /// </summary>
        [DynamoDBHashKey]
        public string DynamoKey { get; private set; }

        /// <summary>
        ///     This is the Konami Code given to us.
        /// </summary>
        public string SetCode { get; set; }

        /// <summary>
        ///     The Konami release date for a set.
        /// </summary>
        /// <remarks>
        ///     Amazon recommends store dates as a string
        ///     in ISO-8601 format.
        /// </remarks>
        public string ReleaseDate { get; set; }
    }
}
