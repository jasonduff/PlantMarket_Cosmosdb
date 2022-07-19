namespace PlantMarket_CosmosDb;

public class Program
{
    static public void Main(string[] args)
    {
        //CosmosDBWriter.WriteToCosmosFromFile("./products.json", "products");

        CosmosDBReader.ReadAllFoldersFromCosmosDB();
    }
}