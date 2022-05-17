open System
open System.IO

let printMeanScore (row : string) =
    let elements = row.Split('\t')
    let name = elements.[0]
    let id = elements.[1]
    let students = elements |> Array.skip 2 |> Array.map float

    let meanScore = students |> Array.average
    let highScore = students |> Array.max 
    let lowScore = students|>  Array.min 
    printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" name id meanScore highScore lowScore

let summarize filePath=
    let rows = File.ReadAllLines filePath
    let studentCount= (rows |> Array.length) - 1
    printfn "The number of students is %i " studentCount
    printfn "name\t\tid\tmeanScore\thighScore\tlowScore"  
    rows |> Array.skip 1 |> Array.iter printMeanScore


[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv.[0]
        if File.Exists filePath then
            printfn "Processing %s " filePath
            summarize filePath
            0
        else
           printfn "File not found: %s " filePath  
           2
    else
        printfn "you need a file bro"
        1  // this is just a exit  code as a return statement
