using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PlantMarket_Azure.helpers;

namespace PlantMarket_Azure.cosmosdb;

public class Program
{
    static public void Main(string[] args)
    {
        //CosmosDBWriter.WriteToCosmosFromFile("./products.json", "products");

        CosmosDBReader.ReadAllFoldersFromCosmosDB();
    }
}