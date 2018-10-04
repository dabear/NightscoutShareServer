using System;
namespace NightscoutShareServer.Utils
{
    public class Config :
#if DEBUG
        ConfigDevelopment
#else
        ConfigProduction
#endif 
    {
        private static readonly Config _instance = new Config();
        public static Config Instance => _instance;

        private Config()
        {
            //disallows creating instances of this class
        }

    }
}
