namespace AsynAwaitWeatherForcasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = "Vadodara, India";
            // Call the method to fetch weather data
            Task<WeatherData> task = FetchWeatherDataAsync(city);
            // Wait for the task to complete
            task.Wait();

            // Display the weather data with city name
            Console.WriteLine($"Weather data for {city}: {task.Result}");
        }

        // Call OpenWeatherMap API to fetch weather data https://openweathermap.org/api
        // Create a C# object from the JSON response
        // Replace Task<string> with the C# object Task<WeatherData>
        static async Task<string> FetchWeatherDataAsync(string url)
        {
            // Fetch web page content asynchronously using HttpClient
            //throw new NotImplementedException();
            // Set the OpenWeatherMap API URL with the city name and your API key
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=YOUR_API_KEY_HERE";

            // Fetch web page content asynchronously using HttpClient
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                // Create a C# object from the JSON response using Newtonsoft.Json
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
                return weatherData;
            }
        }

    }


    public class WeatherData
    {
        public string Name { get; set; }
        public MainData Main { get; set; }
        // Add other properties as needed
    }

    public class MainData
    {
        public double Temp { get; set; }
        // Add other properties as needed
    }

}