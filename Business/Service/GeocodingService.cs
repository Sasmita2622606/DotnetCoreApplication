using Business.Models;
using System.Text.Json;

namespace Business.Service
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeocodingService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["GoogleMaps:ApiKey"];
        }

        public async Task<Location?> GeocodeAsync(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address must not be null or empty.", nameof(address));
            }

            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                // Check if the request was successful
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
                }

                // Log the raw response for debugging
                var rawResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw API Response: {rawResponse}");

                var geocodeResponse = await response.Content.ReadFromJsonAsync<GeocodeResponse>();

                // If the response status is not OK or no results are found, return null
                if (geocodeResponse?.status != "OK" || geocodeResponse?.results == null || geocodeResponse.results.Length == 0)
                {
                    Console.WriteLine("Geocoding failed or no results found.");
                    return null;
                }

                // If geocoding is successful, return the location
                var result = geocodeResponse.results[0];
                return new Location
                {
                    lat = result.Geometry.Location.lat,
                    lng = result.Geometry.Location.lng
                };
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error occurred during geocoding: {ex.Message}");
                return null;
            }
        }
    }
}
