using HackerRank.InterviewChallenge.Services;

public class Program
{
    public static async Task Main(string[] args)
    {
        string keyword = "de";
        string region = "Europe";

        List<string> countries = await WeatherRecordService.FindCountries(keyword, region);
        foreach (var country in countries)
        {
            Console.WriteLine(country);
        }
    }
}