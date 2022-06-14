using OpenSeaWebApi.Interfaces;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Extensions;

// public sealed class TimerServiceExtensions : IHostedService, IAsyncDisposable
// {
//     private readonly Task _completedTask = Task.CompletedTask;
//     private readonly ILogger<TimerServiceExtensions> _logger;
//     private int _executionCount = 0;
//     private Timer? _timer;
//     private readonly IServiceScopeFactory _serviceScopeFactory;

//     public TimerServiceExtensions(ILogger<TimerServiceExtensions> logger,IServiceScopeFactory scopeFactory)
//     {
//         _logger = logger;
//         _serviceScopeFactory = scopeFactory;
//     }

//     public async Task StartAsync(CancellationToken stoppingToken)
//     {
//         using var scope = _serviceScopeFactory.CreateScope();
//         var _openSeaRepository = scope.ServiceProvider.GetRequiredService<IOpenSeaRepository>();

//         _logger.LogWarning("{date} : {Service} is running.", DateTime.UtcNow.ToString() ,nameof(Extensions));

//         _logger.LogWarning("{Service} is working, Added : {result:#,0}", nameof(Extensions), result);


//         _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(50));

//         return _completedTask;
//     }

//     private void DoWork(object? state)
//     {
//         int count = Interlocked.Increment(ref _executionCount);

//         _logger.LogWarning("{Service} is working, execution count: {Count:#,0}", nameof(Extensions), count);
//     }

//     public Task StopAsync(CancellationToken stoppingToken)
//     {
//         _logger.LogWarning(
//             "{Service} is stopping.", nameof(Extensions));

//         _timer?.Change(Timeout.Infinite, 0);

//         return _completedTask;
//     }

//     public async ValueTask DisposeAsync()
//     {
//         if (_timer is IAsyncDisposable timer)
//         {
//             await timer.DisposeAsync();
//         }

//         _timer = null;
//     }

// }



public class TimerServiceExtensions : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<TimerServiceExtensions> _logger;
    private Timer? _timer;
    public TimerServiceExtensions(IServiceScopeFactory serviceScopeFactory, ILogger<TimerServiceExtensions> logger)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Option 1
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogWarning("Worker Started Run at {date}", DateTime.UtcNow.ToString());
                // do async work
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var _openSeaRepository = scope.ServiceProvider.GetRequiredService<IOpenSeaRepository>();

                    (DateTime date, String occurred_after, String occurred_before, int result, int counted) = await _openSeaRepository.OpenSeaUpdate(3);


                    _logger.LogWarning("[ " + date + "  ,  " + date.AddMinutes(3) + " ]" +
                    "\nTimeStamp occurred_after: " + occurred_after +
                    "\nTimeStamp occurred_before: " + occurred_before +
                    "\nTimeStamp occurred_after: " + date +
                    "\nTimeStamp occurred_before: " + date.AddMinutes(3) +
                    "\nSave dInto Database:  " + result.ToString() +
                    "\nNumber of events inside array:  " + counted.ToString());
                    
                    _logger.LogWarning("Worker Finished Run at {date}", DateTime.UtcNow.ToString());
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogWarning("Error encountered:{ex}", ex);
                await Task.Delay(5000, stoppingToken);
                return;
            }
            await Task.Delay(50000, stoppingToken);
        }
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {

        _logger.LogWarning("Worker Starting at {date} : {Service} is running.", DateTime.UtcNow.ToString(), nameof(Extensions));
        return base.StartAsync(cancellationToken);
    }


    public override Task StopAsync(CancellationToken cancellationToken)
    {

        _logger.LogWarning("Worker/{Service} is Stopping at {date}.", nameof(Extensions), DateTime.UtcNow.ToString());
        return base.StopAsync(cancellationToken);
    }
}
