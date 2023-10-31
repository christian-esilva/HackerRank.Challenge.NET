using HackerRank.InterviewChallenge.Services;

namespace Tests
{
    [TestClass]
    public class WeatherRecordTest
    {
        private readonly string keyword = "de";
        private readonly string region = "Europe";

        [TestMethod]
        public async Task WeatherRecordListCountriesIsNotNull()
        {
            List<string> countries = await WeatherRecordService.FindCountries(keyword, region);
            Assert.IsNotNull(countries);
        }

        [TestMethod]
        public async Task WeatherRecordFirstRegisterShouldBeDenmarkAsync()
        {
            List<string> countries = await WeatherRecordService.FindCountries(keyword, region);
            Assert.AreEqual("Denmark", countries[0].Split(',')[0]);
        }

        [TestMethod]
        public async Task WeatherRecordDenmarkPopulationShouldBe5678348()
        {
            List<string> countries = await WeatherRecordService.FindCountries(keyword, region);
            Assert.AreEqual("5678348", countries[0].Split(',')[1]);
        }

        [TestMethod]
        public async Task WeatherRecordListMustReturnsTwoResults()
        {
            List<string> countries = await WeatherRecordService.FindCountries(keyword, region);
            Assert.AreEqual(countries.Count, 2);
        }
    }
}