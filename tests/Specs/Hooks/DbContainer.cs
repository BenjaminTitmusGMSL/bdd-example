namespace Specs.Hooks;

[Binding]
public class DbContainer(ScenarioContext scenarioContext)
{
    private static IFutureDockerImage dockerImage;

    [BeforeTestRun]
    public static async Task BuildImageAsync()
    {
        dockerImage = new ImageFromDockerfileBuilder()
            .WithDockerfileDirectory(CommonDirectoryPath.GetSolutionDirectory(), string.Empty)
            .WithDockerfile("src/Database/Dockerfile")
            .WithCleanUp(true)
            .Build();
        await dockerImage.CreateAsync().ConfigureAwait(false);
    }

    [BeforeScenario]
    public static async Task BuildAndStartContainerAsync(ScenarioContext scenarioContext)
    {
        var container = new ContainerBuilder()
            .WithImage(dockerImage)
            .WithPortBinding(5432, true)
            .WithEnvironment("POSTGRES_HOST_AUTH_METHOD", "trust")
            .WithWaitStrategy(Wait.ForUnixContainer().AddCustomWaitStrategy(new WaitUntil()))
            .Build();
        await container.StartAsync().ConfigureAwait(false);
        var port = container.GetMappedPublicPort(5432);
        scenarioContext["connectionString"] = $"Host=localhost;Port={port};Database=bddexample;Username=postgres;SSL Mode=Disable";
    }

    private sealed class WaitUntil : IWaitUntil
    {
        private readonly IList<string> _command = new List<string> { "pg_isready", "--host", "localhost", "--dbname", "bddexample", "--username", "postgres" };

        public async Task<bool> UntilAsync(IContainer container)
        {
            var execResult = await container.ExecAsync(_command).ConfigureAwait(false);

            return 0L.Equals(execResult.ExitCode);
        }
    }
}