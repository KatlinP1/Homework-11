using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://restcountries.eu/rest/v2/name/eesti";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                Console.WriteLine(response);
                var country = JsonConvert.DeserializeObject<ICollection<Country>>(response);
                if (country.Count>0)
                {
                    var item = country.First();
                    Console.Clear();
                    Console.WriteLine($"Country: {item.Name}");
                    Console.WriteLine($"Capital: {item.Capital}");
                    Console.WriteLine($"Cioc: {item.Cioc}");
                    Console.WriteLine($"Region: {item.Region}");
                    Console.WriteLine($"Population: {item.Population}");
                    Console.WriteLine($"Language (name): {item.Languages.First().Name}");
                    Console.WriteLine($"Language (nativname): {item.Languages.First().NativeName}");
                    Console.WriteLine($"TopLevelDomain: {item.TopLevelDomain.First()}");
                }
            }
            
        }
    }
}