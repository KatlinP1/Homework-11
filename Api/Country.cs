using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api
{
    public class Country
    {
        public string Name { get; set; }
        public string Cioc { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public string Region { get; set; }
        public ICollection<string> TopLevelDomain { get; set; }
        public ICollection<Language> Languages { get; set; }
    }
    public class Language
    {
        [JsonPropertyName("iso639_1")] public string IsoValue { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
    }
    
}