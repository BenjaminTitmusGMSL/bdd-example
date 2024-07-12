using Grpc.Core;

namespace Specs.Drivers;

public class ApiDriver(LogicDriver logicDriver)
{
    private readonly BddService _bddService = new(logicDriver.Logic);

    public async Task UpdateMessage(string message)
    {
        var request = new UpdateMessageRequest();
        request.Message = message;
        await _bddService.UpdateMessage(request, Substitute.For<ServerCallContext>());
    }
}
