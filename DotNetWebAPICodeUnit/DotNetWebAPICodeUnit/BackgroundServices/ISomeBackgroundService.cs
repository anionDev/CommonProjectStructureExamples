namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    internal interface ISomeBackgroundService
    {
        void StartAsync();
        void Stop();
    }
}
