namespace Logic.Interfaces;

public interface IPersistence
{
    public Task SetMessage(string message);

    public Task ClearMessage();
}