using System;
using System.IO;

namespace NightscoutShareServer.Utils
{
    public class ConfigDevelopment : IMyAppConfig
    {

        private string homedir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        //we want this to throw exception if file not found, so don't fall back to empty string here!
        public string NsHost => File.ReadAllText(Path.Combine(homedir, "nshost.txt")).TrimEnd();
        public bool EnableMockedGlucoseMode => false;

    }
}
