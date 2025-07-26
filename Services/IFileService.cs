namespace CatFacts_Netwise.Services
{
    public interface IFileService
    {
        Task AppendToFileAsync(string content);
    }
}
