namespace CatFacts_Netwise.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath;
        public FileService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "CatFacts.txt");
        }

        //Create new txt file
        private async Task CreateFileAsync()
        {
            await File.WriteAllTextAsync(_filePath,$"Yours cat facts{Environment.NewLine}");
            Console.WriteLine($"Created new file {_filePath}");
        }

        //Append a fact to txt file
        public async Task AppendToFileAsync(string content)
        {
            try
            {
                //Check if file exist
                if (!File.Exists(_filePath))
                {
                    await CreateFileAsync();
                }
                await File.AppendAllTextAsync(_filePath, content + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
                throw;
            }
        }
    }
}
