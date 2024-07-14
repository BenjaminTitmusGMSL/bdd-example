namespace Specs.Drivers;

public class PersistenceDriver(ScenarioContext scenarioContext)
{
    public IPersistence Persistence { get; } = new Persistence.Persistence(scenarioContext["connectionString"].ToString());
}
