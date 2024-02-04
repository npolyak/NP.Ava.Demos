namespace WebAPIBackend
{
    public class SimpleService : BackgroundService
    {
        public SimpleService(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<SimpleService>();
        }

        public ILogger Logger { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("SimpleService is starting.");

            stoppingToken.Register(() => Logger.LogInformation("SimpleService is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("SimpleService is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Logger.LogInformation("SimpleService has stopped.");
        }
    }
}
