using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Models;

namespace Database.InMemory
{
    public sealed class InMemoryMethods
    {
        private InMemoryMethods() { }
        private static InMemoryMethods? _instance;
        private Random random = new Random();

        public static InMemoryMethods GetInstance()
        {
            if (_instance == null)
                _instance = new InMemoryMethods();

            return _instance;
        }

        public List<Company> CreateCompanies(int quantity = 10)
        {
            List<Company> listCompanies = new();

            string[] companiesNames = { "Rooxo", "Photospace", "Rooxo", "Tagfeed", "Lazz", "Fiveclub", "Jabbersphere", "Vimbo", "Oyoba", "Devpulse", "Lazz", "Gigabox", "Photobug", "Photobug", "Katz", "Fanoodle", "Lazz", "Aimbo", "Jaxnation", "Teklist", "Thoughtworks", "Devcast", "Photobug", "Voonder", "Realmix", "Flipopia", "Mydo", "Tagcat", "Mydo", "Snaptags" };

            string[] descriptionWords = { "mi", "lacinia", "et", "ante", "sapien", "nec", "consequat", "sapien", "eros", "eget", "nibh", "imperdiet", "et", "maecenas", "luctus", "duis", "dis", "metus", "duis", "a", "ligula", "sapien", "ultrices", "ipsum", "sapien", "ullamcorper", "ac", "tincidunt", "lobortis", "habitasse", "augue", "pulvinar", "libero", "ac", "in", "ac", "iaculis", "consectetuer", "etiam", "mauris", "platea", "tellus", "in", "arcu", "quisque", "justo", "erat", "gravida", "felis", "orci" };

            int totalPhrases = random.Next(20, 30);
            List<string> randomWords = new();

            for (int i = 1; i <= totalPhrases; i++)
            {
                string randomPhrase = string.Join(" ",(from word in descriptionWords.OrderBy(x => Guid.NewGuid())
                                    select word).Take(random.Next(5, 10)).ToList());
                randomWords.Add(randomPhrase);
            }

            var listCompaniesNames = (from cp in companiesNames.Select((name, index) => new { name, index })
                                      let randomIndex = random.Next(0, randomWords.Count)
                                      select new { Guid_ = Guid.NewGuid(), Id = cp.index + 1, Name = cp.name, Description = randomWords[randomIndex] })
                                 .ToList()
                                 .OrderBy(x => x.Guid_)
                                 .Take(quantity)
                                 .ToList();

            foreach (var company in listCompaniesNames)
            {
                listCompanies.Add(new Company()
                {
                    Id = company.Id,
                    Name = company.Name,
                    Description = company.Description
                });
            }

            return listCompanies;
        }
    }
}