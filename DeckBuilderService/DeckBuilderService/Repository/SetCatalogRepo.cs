using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using DeckBuilderService.Models.Data;

namespace DeckBuilderService.Repository
{
    public class SetCatalogRepo
    {
        private readonly DynamoDBContext dynamoContext;

        public SetCatalogRepo(IAmazonDynamoDB dynamoDbClient)
        {
            this.dynamoContext = new DynamoDBContext(dynamoDbClient);
        }

        public async Task<IEnumerable<SetReleases>> GetSetCatalog()
        {
            return await this.dynamoContext
                .ScanAsync<SetReleases>(new List<ScanCondition>())
                .GetRemainingAsync();
        }
    }
}
