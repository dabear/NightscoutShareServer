using System;
namespace NightscoutShareServer.Utils
{
    public interface IMyAppConfig
    {
        string NsHost { get; }
        bool EnableMockedGlucoseMode { get; }

    }

}
