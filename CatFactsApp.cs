using CatFacts_Netwise.Services;

namespace CatFacts_Netwise
{
    public class CatFactsApp : ICatFactsApp
    {
        private readonly ICatFactsService _catFactsService;
        private readonly IFileService _fileService;

        public CatFactsApp(ICatFactsService catFactsService, IFileService fileService)
        {
            _catFactsService = catFactsService;
            _fileService = fileService;
        }

        public async Task RunApp()
        {
            Console.WriteLine("---- Cat Facts Application ----");
            Console.WriteLine();

            //Main loop
            while (true)
            {
                Console.Write("Press any key to get a cat fact (or 'q' to quit): ");
                var key = Console.ReadKey();
                Console.WriteLine();

                //check for quit condition
                if (key.KeyChar == 'q' || key.KeyChar == 'Q')
                {
                    break;
                }

                await ProcessCatFactRequestAsync();
                Console.WriteLine();
            }
        }

        private async Task ProcessCatFactRequestAsync()
        {
            try
            {
                Console.WriteLine("Fetching cat fact...\n");

                //Get CatFact from service
                var catFact = await _catFactsService.GetRandomCatFactAsync();

                if (catFact != null)
                {
                    Console.WriteLine($"Cat Fact: {catFact.Fact}");
                    Console.WriteLine($"Length: {catFact.Length} characters\n");

                    string formatedFact = $"{catFact.Fact} [Length: {catFact.Length}]";
                    //Append fact to file 
                    await _fileService.AppendToFileAsync(formatedFact);
                    Console.WriteLine("Cat fact saved to file");
                }
                else
                {
                    Console.WriteLine("Failed to fetch cat fact. Please try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}
