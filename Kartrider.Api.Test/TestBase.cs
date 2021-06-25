namespace Kartrider.Api.Test
{
    public class TestBase
    {
        protected static KartriderApi kartriderApi = KartriderApi.GetInstance(TestSetting.ApiKey);
    }
}