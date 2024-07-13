namespace Persistence

open Logic.Interfaces
open Npgsql
open SqlFun.Queries
open SqlFun.NpgSql
open SqlFun
open SqlFun.Transforms

type Persistence(connection: string) =
    let createConnection () = new NpgsqlConnection(connection)
    let generatorConfig = createDefaultConfig createConnection
    let proc name = proc generatorConfig name
    let runAsync f = AsyncDb.run createConnection f

    let clear_messages_proc: AsyncDb<unit> =
        proc "bddexample.clear_messages" () |> AsyncDb.map resultOnly

    let set_message_proc: string -> AsyncDb<unit> =
        proc "bddexample.set_message" >> AsyncDb.map resultOnly

    let clear_messages = 
        async {
            let! result = clear_messages_proc |> runAsync
            return result
        }

    let set_message message =
        async {
            let! result = set_message_proc message |> runAsync
            return result
        }

    interface IPersistence with
        member this.ClearMessage() = Async.StartAsTask clear_messages

        member this.SetMessage(message) = Async.StartAsTask (set_message message)