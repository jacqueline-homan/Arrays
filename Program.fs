open System
open System.IO

let numbers = [|0..10|]
let evenMultiples =
    numbers 
    |> Array.map(fun x -> 2 * x)
let result =
    evenMultiples
    |> Array.iter(printfn "%A")

let foods = [| "spaghetti"; "bruschetta"; "cannoli"; "cuscusu"|]
printfn "%A" foods
//.NET doesn't have an init capitalize function, so we derive one
let initCap str =
    if String.IsNullOrEmpty str then
        str
    else
        str.[0].ToString().ToUpperInvariant() + str.[1..]

let initCapFoods =
    foods
    |> Array.map(fun food -> initCap food)
    |> Array.iter(printfn "%A")


let vowels = "aeiouAEIOU"

let vowelPos(str:string) =
    str.ToCharArray()
    |> Array.mapi(fun i c -> if vowels.Contains(c.ToString()) then
                                sprintf "Vowel %c at %i position" c i 
                             else 
                                "Consonant")
   

let vowelPositon(str:string) =
    str.ToCharArray()
    |> Array.iteri(fun i c -> if vowels.Contains(c.ToString()) then
                                printfn "Vowel %c at position %i" c i)
vowelPos "Jacqueline" |> printfn "%A"

//Using a filtering operation when payday falls on a weekend

let devTeamPaydays year =
    [| 
        for i in 1..12 do
            let firstDay = DateTime(year, i, 1)
            let dayCount = float(DateTime.DaysInMonth(year, i))
            let lastDay = firstDay.AddDays(dayCount - 1.)
            yield lastDay
    |]

let isWeekend (day:DateTime) =
    day.DayOfWeek = DayOfWeek.Saturday || day.DayOfWeek = DayOfWeek.Sunday

let paydayAlerts year =
    devTeamPaydays year
    |> Array.filter(fun p -> isWeekend p)
printfn "Payday alert for %A" (paydayAlerts 2016)

//Using a filtering operation on a sequence to make sure those who are devs are paid on alert days
let teamCodecatenation =
    [("Marissa", "Senior Administrative Support", "P/T")
     ("Matt", "Sales", "P/T")
     ("Jacqueline", "Developer", "F/T")
     ("Jerold", "Senior Developer", "F/T")
     ("Reed", "Senior Developer", "F/T")]

let devTeam =
    teamCodecatenation
    |> Seq.map(fun(name, role, status) -> role)
    |> Seq.filter(fun role -> role.Contains "Developer")
    |> Seq.iter(printfn "%s")  


let namesofdevs =
    teamCodecatenation
    |> Seq.map(fun(name, age, language) -> name)
    |> Seq.filter(fun name -> name.StartsWith "J")
    |> Seq.iter(printfn "%s")


let arr1 = [|"Albion"; "Fairview"; "Harborcreek"; "North East"|]
let arr2 = [|16401;16415;16421; 16428|]

let arrProd (arr1: array<string>)(arr2:array<int>) =
    Array.zip arr1 arr2
arrProd arr1 arr2 |> printfn "%A"



let easy = [|"F#"; "Functional Programming"|]
let reducer(easy:array<string>) =
    easy
    |> Array.reduce(fun acc elem -> sprintf "%s, %s" acc elem)
reducer(easy) |> printfn "%s"

let dnaCharacters = [|"A"; "A"; "C"; "C"; "C"; "G"; "G"; "T"|]
let reducer2(dnaCharacters:array<string>) =
    dnaCharacters
    |> Array.reduce(+)
reducer2 dnaCharacters |> printfn "%s"



[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
    0 // return an integer exit code

