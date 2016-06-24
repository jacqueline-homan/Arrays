let vowelPositions (str:string) =
    let vowels = "aeiouAEIOU"
    str.ToCharArray()
    |> Array.mapi(fun i c -> (if vowels.Contains(c.ToString()) then
                                sprintf "Vowel %c at postion %i" c i
                             else
                                 "Some other letter"))

let devs =
    [("Evan", 41, "Haskell")
     ("Jacque", 48, "F#")
     ("Mylo", 25, "JavaScript")]
let namesofdevs =
    devs
    |> Seq.map(fun(name, age, language) -> name)
    |> Seq.filter(fun name -> name.Contains "a")
    |> Seq.iter(printfn "%s")