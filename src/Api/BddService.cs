using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Logic.Interfaces;
using Service;

namespace Api;

public class BddService(ILogic logic) : Bdd.BddBase
{
    public override async Task<Empty> UpdateMessage(UpdateMessageRequest request, ServerCallContext context)
    {
        await logic.UpdateMessage(request.Message);
        return new Empty {};
    }
}
