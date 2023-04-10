//using static System.Net.WebRequestMethods;


using Newtonsoft.Json.Linq;

string key = File.ReadAllText("appsettings.json");
string APIkey = JObject.Parse(key).GetValue("DefaultKey").ToString();

Console.WriteLine("Please enter your zip code: ");
var zip = Console.ReadLine();

var client = new HttpClient();
var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appID={APIkey}&units=imperial";
var weatherResponse = client.GetStringAsync(weatherURL).Result;
var formattedResponse = JObject.Parse(weatherResponse).GetValue("main").ToString();
var tempResponse = JObject.Parse(formattedResponse).GetValue("temp");
Console.WriteLine($"The current temperature is: {tempResponse} degrees Fahrenheit");


