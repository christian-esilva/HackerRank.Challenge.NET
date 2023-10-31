using System.Text.Json;
using HackerRank.InterviewChallenge.Models;

namespace HackerRank.InterviewChallenge.Services
{
    public class WeatherRecordService
    {
        public const string BASE_URL = "https://jsonmock.hackerrank.com/api/countries/search";

        public static async Task<List<string>> FindCountries(string keyword, string region)
        {
            List<string> result = new();
            HttpClient client = new()
            {
                BaseAddress = new Uri(BASE_URL)
            };
            int page = 1;
            bool hasNextPage = true;

            while (hasNextPage)
            {
                string apiUrl = $"?region={region}&name={keyword}&page={page}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                // Desserialização
                Result data = JsonSerializer.Deserialize<Result>(responseBody, options);

                foreach (var record in data.Data)
                {
                    result.Add($"{record.Name},{record.Population}");
                }

                page++;
                if (page > data.Total)
                {
                    hasNextPage = false;
                }
            }

            // Ordenar a lista de países por população e, em seguida, por nome
            var sortedResult = result
                .OrderBy(country => int.Parse(country.Split(',')[1]))
                .ThenBy(country => country.Split(',')[0])
                .ToList();

            return sortedResult;
        }
    }
}
