using Microsoft.Extensions.Configuration;

namespace Kartrider.Api.Test
{
    public static class TestSetting
    {
        public static readonly string ApiKey = "";

        static TestSetting()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json")
                .AddEnvironmentVariables("API_TEST")
                .Build();

            ApiKey = configuration["ApiKey"];
        }
    }
}