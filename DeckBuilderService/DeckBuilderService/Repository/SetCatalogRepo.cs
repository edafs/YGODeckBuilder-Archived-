using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using DeckBuilderService.Models.Data;

namespace DeckBuilderService.Repository
{
    /// <summary>
    ///     Operations on the set Catalog Dynamo Table. 
    /// </summary>
    /// <remarks>
    ///     Data Model: <see cref="SetReleases"/>.
    /// </remarks>
    public class SetCatalogRepo
    {
        /// <summary>
        ///     The DynamoDB context by Amazon.
        /// </summary>
        private readonly DynamoDBContext dynamoContext;

        /// <summary>
        ///     Default constructor for <see cref="SetCatalogRepo"/>.
        /// </summary> 
        public SetCatalogRepo(IAmazonDynamoDB dynamoDbClient)
        {
            if (dynamoDbClient == null)
            {
                throw new AmazonDynamoDBException("Amazon DB context not properly set up.");
            }

            this.dynamoContext = new DynamoDBContext(dynamoDbClient);
        }

        /// <summary>
        ///     Get the full set catalog from dynamoDB. 
        /// </summary>
        public async Task<IEnumerable<SetReleases>> GetSetCatalog()
        {
            try
            {
                using (DynamoDBContext context = this.dynamoContext)
                {
                    return await context
                        .ScanAsync<SetReleases>(new List<ScanCondition>())
                        .GetRemainingAsync();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Queries the set catalog for something based on the key.
        /// </summary>
        public async Task<SetReleases> SearchFromCatalog(string key)
        {
            try
            {
                using(DynamoDBContext context = this.dynamoContext)
                {
                    return await context
                        .LoadAsync<SetReleases>(key);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
