namespace Specs.Drivers;

public class PersistenceDriver
{
    public IPersistence Persistence { get; } = new Persistence.Persistence("");
}
