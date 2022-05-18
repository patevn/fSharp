open System
open System.IO

type Student = 
    {
    Name : string
    Id : string
    MeanScore : float
    MinScore : float
    MaxScore : float

    }

module Student =   // module is just a group fo code, like in JS
    let fromString(s: string) = 
        let elements = s.Split('\t')
        let name = elements.[0]
        let id = elements.[1]
        let students = elements |> Array.skip 2 |> Array.map float

        let meanScore = students |> Array.average
        let maxScore = students |> Array.max 
        let minScore = students|>  Array.min
        { // the last thing in a function is the return
            Name = name
            Id = id
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }


    let printSummary (s : Student) =
        printfn "%s\t%s\t%0.1f\t%0.1f\t%0.1f" s.Name s.Id s.MeanScore s.MaxScore s.MinScore

let summarize filePath=
    let rows: Student[] = File.ReadAllLines filePath  |> Array.skip 1 |> Array.map Student.fromString |> Array.sortBy(fun student -> student.Name)  // fun here is how F# does lambda (anons)

    let studentCount= (rows |> Array.length) - 1 
    printfn "The number of students is %i " studentCount
    printfn "name\t\tid\tmeanScore\thighScore\tlowScore"  
    rows |> Array.skip 1 |> Array.iter Student.printSummary 


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
