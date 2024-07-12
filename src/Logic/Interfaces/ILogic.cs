namespace Logic.Interfaces;

public interface ILogic
{
    public Task UpdateMessage(string message);

    public Task ClearMessage();
}