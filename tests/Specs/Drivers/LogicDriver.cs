namespace Specs.Drivers;

public class LogicDriver(PersistenceDriver persistenceDriver, EmailSenderDriver emailSenderDriver)
{
    public ILogic Logic { get; } = new Logic.Logic(persistenceDriver.Persistence, emailSenderDriver.EmailSender);
}
