module OrderParser

    open System.Collections.Generic

    let parse (str : string) =
        let join (sep : string) (str : string[]) =
            System.String.Join(sep, str)
        let countNouns =
            Map.ofList [(1, ""); (2, "Double")]
        try
            str.Split(',')
            |> Array.countBy (fun x -> x)
            |> Array.map (fun (item, count) -> countNouns.[count] + item)
            |> Array.map (fun str -> str.Trim())
            |> join ", "
        with
        | :? KeyNotFoundException -> "INVALID ORDER"