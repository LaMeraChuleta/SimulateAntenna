using MMM.Data;
using static MMM.Data.DataManager;

namespace SimulateAntenna
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var dataManager = new DataManager(ConnectionTypes.SOCKET, "172.16.30.134", 0);
                dataManager.OpenConnection();
                while (!stoppingToken.IsCancellationRequested)
                {                                                                                
                    dataManager.Set("antennas.1.advanced.attenuation", "15");
                    dataManager.Set("antennas.1.advanced.attenuation", "16");
                    //dataManager.Set("antennas.1.advanced.attenuation", "17");
                    //dataManager.Set("antennas.1.advanced.attenuation", "18");
                    //dataManager.Set("antennas.1.advanced.attenuation", "19");
                    //dataManager.Set("antennas.1.advanced.attenuation", "20");
                    await Task.Delay(30000, stoppingToken);
                }
                dataManager.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
