namespace Service.Services;

public abstract class TimedHostedService(TimeSpan timeSpan) : BackgroundService
{
    protected abstract void DoWork(CancellationToken cancellationToken);

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        DoWork(cancellationToken);

        using PeriodicTimer timer = new(timeSpan);

        try
        {
            while (await timer.WaitForNextTickAsync(cancellationToken))
            {
                DoWork(cancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }
}
