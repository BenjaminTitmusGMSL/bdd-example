namespace Persistence

open Logic.Interfaces

type Persistence =
    interface IPersistence with
        member this.ClearMessage() = failwith "todo"
        member this.SetMessage(message) = failwith "todo"