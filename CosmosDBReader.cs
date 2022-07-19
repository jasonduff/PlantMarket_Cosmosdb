using System.Collections;
using Newtonsoft.Json;
using PlantMarket_Azure.helpers;
using Product = PlantMarket_Azure.helpers.Product;

namespace PlantMarket_CosmosDb;

public class CosmosDBReader
{
    private static Dictionary<Type, string> containerNames = new Dictionary<Type, string>()
    {
        {typeof(Cart),"cart"},
        {typeof(CartProduct),"cartProducts"},
        {typeof(Config),"config"},
        {typeof(PlantNames),"plantNames"},
        {typeof(Product),"products"},
        {typeof(ProductDetail),"productDetail"},
        {typeof(Sale),"sale"},
        {typeof(SaleProduct),"saleProducts"},
        {typeof(UserInfo),"user"},
    };

    private static string outputPathRoot = $"/Users/jasonduff/projects/PlantMarket_Azure/PlantMarket_Azure/PlantMarket_CosmosDb/cosmosdb/db/dump_{DateTime.Now:yyyyMMdd:hh:mm:ss}";

    public static void ReadAllFoldersFromCosmosDB()
    {
        ReadFromCosmosToFile<Cart>("cart");
        ReadFromCosmosToFile<CartProduct>("cartProducts");
        ReadFromCosmosToFile<Config>("config");
        ReadFromCosmosToFile<PlantNames>("plantNames");
        ReadFromCosmosToFile<Product>("products");
        ReadFromCosmosToFile<Sale>("sale");
        ReadFromCosmosToFile<SaleProduct>("saleProducts");
        ReadFromCosmosToFile<UserInfo>("user");

    }
    
    private static void ReadFromCosmosToFile<T>(string container)
    {
        var items = GetAllItemsFromCosmosDBContainer<T>(container);
        
        WriteJsonItems(outputPathRoot, items, container);
    }
    
    private static void WriteJsonItems(string path, IEnumerable items, string containerName)
    {
        // var folderName = containerName;
        // var fullPath = Path.Join(path, folderName);
        Directory.CreateDirectory(path);
        
        var filename = containerName + ".json";
        var fullPathAndFile = Path.Join(path, filename);

        Console.WriteLine($"writing to: {fullPathAndFile}");
        using var sw = System.IO.File.AppendText(fullPathAndFile);
        var output = JsonConvert.SerializeObject(items);
        sw.Write(output);
    }

    public static IEnumerable<T> GetAllItemsFromCosmosDBContainer<T>(string containerName)
    {
        var container = CosmosDBInitializer.GetContainer(containerName);
        var query = container.GetItemLinqQueryable<T>(true);
        return query.ToArray();
    }
}