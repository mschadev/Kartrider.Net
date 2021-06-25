using Microsoft.Extensions.Configuration;

namespace Kartrider.Api.Test
{
    public static class TestSetting
    {
        public static readonly string ApiKey = "";

        static TestSetting()
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables("API_TEST")
                .AddJsonFile("testsettings.json")
                .Build();

            ApiKey = configuration["ApiKey"];
        }
    }
}