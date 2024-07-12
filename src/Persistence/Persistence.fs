namespace Persistence

open System.Threading.Tasks
open Logic.Interfaces

type Persistence() =
    interface IPersistence with
        member this.ClearMessage() = Task.CompletedTask
        member this.SetMessage(message) = Task.CompletedTask