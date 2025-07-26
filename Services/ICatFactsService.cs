using CatFacts_Netwise.Models;

namespace CatFacts_Netwise.Services
{
    public interface ICatFactsService
    {
        Task<CatFact?> GetRandomCatFactAsync();
    }
}
