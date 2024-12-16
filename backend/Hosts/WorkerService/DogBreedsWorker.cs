using Hangfire;
using HangfireJobs.Jobs;

namespace WorkerService;

public class DogBreedsWorker(
    ILogger<DogBreedsWorker> logger,
    IBackgroundJobClient jobClient) : BackgroundService
{
    private readonly ILogger<DogBreedsWorker> _logger = logger;
    private readonly IBackgroundJobClient _jobClient = jobClient;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RecurringJob.AddOrUpdate<DogBreedsUpsertJob>(
            nameof(DogBreedsUpsertJob),
            job => job.ExecuteAsync(stoppingToken),
            Cron.Hourly());

        return Task.CompletedTask;
    }
}
