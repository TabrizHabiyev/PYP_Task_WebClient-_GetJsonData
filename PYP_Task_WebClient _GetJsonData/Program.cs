
using Newtonsoft.Json;
using System.Net;

List<string> urls = new List<string>()
{
    "http://country.io/names.json",
    "http://country.io/phone.json",
    "http://country.io/iso3.json",
    "http://country.io/capital.json",
    "http://country.io/currency.json",
    "http://country.io/continent.json"
};

// Create Country List
List<Country> countryList = new List<Country>();

foreach (var url in urls)
{
    var json = new WebClient().DownloadString(url);
    var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

    foreach (var item in data)
    {
        var country = countryList.FirstOrDefault(x => x.Code == item.Key);
        if (country == null)
        {
            country = new Country();
            country.Code = item.Key;
            countryList.Add(country);
        }

        if (url == urls[0])
            country.Name = item.Value;
        else if (url == urls[1])
            country.Phone = item.Value;
        else if (url == urls[2])
            country.ISO = item.Value;
        else if (url == urls[3])
            country.Capital = item.Value;
        else if (url == urls[4])
            country.Currency = item.Value;
        else if (url == urls[5])
            country.Continent = item.Value;
    }
}


// Display the data

Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "Phone",   "ISO", "Capital", "Currency", "Continent", "Code", "Name");
Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", "-------", "-----", "----------", "----------", "-----------------------", "----------", "----------");

int i = 0;
foreach (var item in countryList)
{
    Console.WriteLine("{0,-10}{1,-10}{2,-15}{3,-15}{4,-25}{5,-15}{6,-15}", item.Phone, item.ISO, item.Capital, item.Currency, item.Continent, i, item.Name);
    i++;
}



public class Country
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string ISO { get; set; }
    public string Capital { get; set; }
    public string Currency { get; set; }
    public string Continent { get; set; }
}