using System.Text.Json.Serialization;

namespace CatFacts_Netwise.Models
{
    public class CatFact
    {
        [JsonPropertyName("fact")]
        public string Fact { get; set; } = string.Empty;
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
