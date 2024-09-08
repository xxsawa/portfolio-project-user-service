using Microsoft.Azure.Cosmos;

namespace Source.CosmosDbService
{
    public class CosmosDbConnection
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDbConnection(string connectionString, string databaseName, string containerName)
        {
            _cosmosClient = new CosmosClient(connectionString);
            _container = _cosmosClient.GetContainer(databaseName, containerName);
            _container.CreateItemAsync<Models.User>(UserFactory.CreateUser("John Doe", "d@s.sk"));

        }

        public async Task<ItemResponse<T>> AddItemAsync<T>(T item, string partitionKey)
        {
            return await _container.CreateItemAsync(item, new PartitionKey(partitionKey));
        }

        public async Task<ItemResponse<Models.User>> AddUserAsync()
        {
            return await _container.CreateItemAsync<Models.User>(UserFactory.CreateUser("John Doe", "d@s.sk"));
        }

    }
}
