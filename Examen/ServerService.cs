using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Examen
{
    public class ServerService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string baseUrl = "http://localhost:5252";
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task<List<Article>> GetAllDataAsync()
        {
            var response = await client.GetAsync($"{baseUrl}articles");
            if (!response.IsSuccessStatusCode)
            {
                return new List<Article>();
            }
            string json = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Article>>(json, jsonOptions);
            return list ?? new List<Article>();
        }
        public async Task<Article> GetDataByIdAsync()
        {
            Console.WriteLine("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                return new Article();
            }
            var response = await client.GetAsync($"{baseUrl}/articles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return new Article();
            }
            string json = await response.Content.ReadAsStringAsync();
            var article = JsonSerializer.Deserialize<Article>(json, jsonOptions);
            return article ?? new Article();
        }
        public async Task<Article> GetDataByTitleAsync()
        {
            Console.WriteLine("Enter Title: ");
            string title = Console.ReadLine();
            var response = await client.GetAsync($"{baseUrl}/data/title/{title}");
            if (!response.IsSuccessStatusCode)
            {
                return new Article();
            }
            string json = await response.Content.ReadAsStringAsync();
            var article = JsonSerializer.Deserialize<Article>(json, jsonOptions);
            return article ?? new Article();
        }
        public async Task<Article> GetDataByAuthorAsync()
        {
            Console.WriteLine("Enter Author: ");
            string author = Console.ReadLine();
            var response = await client.GetAsync($"{baseUrl}/data/author/{author}");
            if (!response.IsSuccessStatusCode)
            {
                return new Article();
            }
            string json = await response.Content.ReadAsStringAsync();
            var article = JsonSerializer.Deserialize<Article>(json, jsonOptions);
            return article ?? new Article();
        }
        public async Task<Article> GetDataByDateAsync()
        {
            Console.WriteLine("Enter Date (yyyy-MM-dd): ");
            string date = Console.ReadLine();
            var response = await client.GetAsync($"{baseUrl}/data/date/{date}");
            if (!response.IsSuccessStatusCode)
            {
                return new Article();
            }
            string json = await response.Content.ReadAsStringAsync();
            var article = JsonSerializer.Deserialize<Article>(json, jsonOptions);
            return article ?? new Article();
        }
        public static async Task<int?> AddArticleAsync()
        {
            Console.WriteLine("Enter Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Enter Date (yyyy-MM-dd): ");
            string date = Console.ReadLine();
            var newArticle = new
            {
                title,
                description,
                author,
                date
            };
            var json = JsonSerializer.Serialize(newArticle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseUrl}/data", content);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Article>(resultJson, jsonOptions);
            return result?.id;
        }
        public async Task<bool> DeleteArticleAsync()
        {
            Console.WriteLine("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                return false;
            }
            var response = await client.DeleteAsync($"{baseUrl}/data/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateArticleAsync()
        {
            Console.WriteLine("Enter ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                return false;
            }
            Console.WriteLine("Enter Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Enter Date (yyyy-MM-dd): ");
            string date = Console.ReadLine();
            var updatedArticle = new
            {
                title,
                description,
                author,
                date
            };
            var json = JsonSerializer.Serialize(updatedArticle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{baseUrl}/data/{id}", content);
            return response.IsSuccessStatusCode;
        }
    }
}
