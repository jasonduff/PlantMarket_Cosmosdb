using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PlantMarket_Azure;
using PlantMarket_Azure.helpers;

namespace PlantMarket_CosmosDb;

public static class CosmosDBWriter
{
    public static async Task AddProductsToCosmos(string filePath)
    {
        var products = ReadJSONFromFile<Product>(filePath);

        foreach (var product in products)
        {
            product.Id = Guid.NewGuid().ToString();
            var logger = new Logger<Program>(new LoggerFactory());
            var newProduct = await Checkout.CreateNewProduct(product, logger);
        }        
    }
    
    public static T[] ReadJSONFromFile<T>(string filePath)
    {
        using (StreamReader r = new StreamReader(filePath))
        {
            var json = r.ReadToEnd();
            var items = JsonConvert.DeserializeObject<T[]>(json);
            return items;
        }
    }
}