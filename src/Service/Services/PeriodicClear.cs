namespace Service.Services;

using Logic.Interfaces;

public sealed class PeriodicClear(ILogic logic) : TimedHostedService(TimeSpan.FromMinutes(10))
{
    protected override async void DoWork(CancellationToken cancellationToken) =>
        await logic.ClearMessage();
}
