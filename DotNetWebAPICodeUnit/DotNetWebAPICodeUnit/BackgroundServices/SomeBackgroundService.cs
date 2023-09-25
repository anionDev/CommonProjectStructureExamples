namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    public class SomeBackgroundService :ISomeBackgroundService
    {
        public bool Enabled => true;

        public void StartAsync()
        {
            // TODO
        }

        public void StartAsyncImplementation()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            // TODO
        }

        public void StopImplementation()
        {
            throw new System.NotImplementedException();
        }
    }
}
