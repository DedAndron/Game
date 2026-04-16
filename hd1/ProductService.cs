using System.Net.Http;
using System.Threading.Tasks;

class ProductService
{
    private static readonly HttpClient client = new HttpClient();
    private const string baseUrl = "https://fakestoreapi.com/products";

    public async Task<string> GetAllProductsAsync()
    {
        foreach (var header in client.DefaultRequestHeaders)
        {
            Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
        }
        return await client.GetStringAsync(baseUrl);
    }

    public async Task<string> GetProductByIdAsync(int id)
    {
        string url = $"{baseUrl}/{id}";
        return await client.GetStringAsync(url);
    }
}
