using CatFacts_Netwise.Models;
using System.Text.Json;

namespace CatFacts_Netwise.Services
{
    public class CatFactsService : ICatFactsService
    {
        private readonly HttpClient _httpClient;

        public CatFactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFact?> GetRandomCatFactAsync()
        {
            try
            {
                //GET request for cat fact
                var response = await _httpClient.GetAsync("fact");
                response.EnsureSuccessStatusCode();

                //read requested content as string
                var jsonContent = await response.Content.ReadAsStringAsync();
                //deserialize json to CatFact object
                var catFact = JsonSerializer.Deserialize<CatFact>(jsonContent);

                return catFact;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HTTP error: {e.Message}");
                return null;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON error: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
                return null;
            }
        }
    }
}
