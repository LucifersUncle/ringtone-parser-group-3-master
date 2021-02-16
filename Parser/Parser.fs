module Parser

open System.Security.Cryptography
open FParsec
open Microsoft.VisualBasic

type Duration = 
    | Half = 0
    | Quarter = 1
    | Eight = 2
    | Sixteenth = 3
    | Thirtysecond = 4
    
type Key =
    | A = 0
    | Asharp = 1
    | B = 2
    | C = 3
    | Csharp = 4
    | D = 5
    | Dsharp = 6
    | E = 7
    | F = 8
    | Fsharp = 9
    | G = 10
    | Gsharp = 11

type Pauses = | Pause = 1

type Octaves =
    | First = 1
    | Second = 2
    | Third = 3

type Extended = {
    type1: int option
    type2: string option
}

failwith "Implement here" 
type Token = {
    Duration : Duration
    //Extended : Extended
    Key : Key
    Pauses : Pauses
    Octave: Octaves
}
//Melody
//type melody(  Mel : string ) = member this.mel = "8e2 8#d2 8e2 8#d2 8e2 8b1 8d2 8c2 4a1 8- 8c1 8e1 8a1 4b1 8- 8e1 8#g1 8b1 4c2 8-
//8e1 8e2 8#d2 8e2 8#d2 8e2 8b1 8d2 8c2 4a1 8- 8c1 8e1 8a1 4b1 8- 8e1 8c2
//8b1 4a1"

let melody = "8e2 8#d2 8e2 8#d2 8e2 8b1 8d2 8c2 4a1 8- 8c1 8e1 8a1 4b1 8- 8e1 8#g1 8b1 4c2 8- 8e1 8e2 8#d2 8e2 8#d2 8e2 8b1 8d2 8c2 4a1 8- 8c1 8e1 8a1 4b1 8- 8e1 8c2 8b1 4a1"
let list_durations() =  

let pScore: Parser<Token list, unit> = failwith "Implement here" // TODO 2 builder parser
//==Parser for durations==//
let parseDuration  durationLength =
    (stringReturn "2" Duration.Half) <|>
    (stringReturn "4" Duration.Quarter) <|>
    (stringReturn "8" Duration.Eight) <|>
    (stringReturn "16" Duration.Sixteenth) <|>
    (stringReturn "16" Duration.Thirtysecond)

//==Parser for Chords==//
let parseChords chords =
    (stringReturn "A" Key.A) <|>
    (stringReturn "A#" Key.Asharp) <|>
    (stringReturn "B" Key.B) <|>
    (stringReturn "C" Key.C) <|>
    (stringReturn "C#" Key.Csharp) <|>
    (stringReturn "D" Key.D) <|>
    (stringReturn "D#" Key.Dsharp) <|>
    (stringReturn "E" Key.E) <|>
    (stringReturn "F" Key.F) <|>
    (stringReturn "F#" Key.Fsharp) <|>
    (stringReturn "G" Key.G) <|>
    (stringReturn "G#" Key.Gsharp) <|>  

//==Parser for Octaves==//
let parseOctaves octaves =
    (stringReturn "1" Octaves.First) <|>
    (stringReturn "2" Octaves.Second) <|>
    (stringReturn "3" Octaves.Third)

//==Parser for Pauses==//
let parsePauses pauses =
    (stringReturn "-" Pauses.Pause)

let parse (input: string): Choice<string, Token list> =
    match run pScore input with
    | Failure(errorMsg,_,_)-> Choice1Of2(errorMsg)
    | Success(result,_,_) -> Choice2Of2(result)

// Helper function to test parsers
let test (p: Parser<'a, unit>) (str: string): unit =
    match run p str with
    | Success(result, _, _) ->  printfn "Success: %A" result
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg


// TODO 3 calculate duration from token.
// bpm = 120 (bpm = beats per minute)
// 'Duration in seconds' * 1000 * 'seconds per beat' (if extended *1.5)
// Half note: 2 seconds
// Quarter note: 1 second
// Eight note: 1/2 second
// Sixteenth note 1/4 second
// thirty-second note: 1/8
let durationFromToken (token: Token): float = failwith "Implement here"

// TODO 4 calculate overall index of octave
// note index + (#octave-1 * 12)
let overallIndex (note, octave) = failwith "Implement here"

// TODO 5 calculate semitones between to notes*octave
// [A; A#; B; C; C#; D; D#; E; F; F#; G; G#]
// overallIndex upper - overallIndex lower
let semitonesBetween lower upper = failwith "Implement here"

// TODO 6
// For a tone frequency formula can be found here: http://www.phy.mtu.edu/~suits/NoteFreqCalcs.html
// 220 * 2^(1/12) * semitonesBetween (A1, Token.pitch) 
let frequency (token: Token): float = failwith "Implement here"