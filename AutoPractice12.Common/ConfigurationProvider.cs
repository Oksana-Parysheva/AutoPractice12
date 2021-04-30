using Microsoft.Extensions.Configuration;

namespace AutoPractice12.Common
{
    public class ConfigurationProvider
    {
        private static readonly string AppSettings = "appsettings.json";

        private static IConfiguration _currentConfiguration;

        private static void Init()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile(AppSettings);
            _currentConfiguration = configurationBuilder.Build();
        }

        public static IConfiguration GetCurrent()
        {
            if (_currentConfiguration is null)
            {
                Init();
            }

            return _currentConfiguration;
        }
    }
}
