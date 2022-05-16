open System

let sayHello person =
    printfn "Hello %s from my F# program!" person

[<EntryPoint>]
let main argv =
    Array.iter sayHello argv
    let peter: string = "HI"
    printfn "Nice to meet you."
    0
