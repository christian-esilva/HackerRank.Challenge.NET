namespace HackerRank.InterviewChallenge.Models
{
    public class Result
    {

        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<WeatherRecord> Data { get; set; }

        public Result()
        {
            Data = new List<WeatherRecord> { };
        }

    }
}
