namespace PlantMarket_CosmosDb;

public class Program
{
    static public async Task Main(string[] args)
    {
        await CosmosDBWriter.AddProductsToCosmos("/Users/jasonduff/projects/PlantMarket_Azure/PlantMarket_Azure/PlantMarket_CosmosDb/cosmosdb/db/new_products.json");

        // CosmosDBReader.ReadAllFoldersFromCosmosDB();
    }
}