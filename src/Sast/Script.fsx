﻿#r "./bin/Debug/Sast.dll"

open System
open ScribbleGenerativeTypeProvider
open ScribbleGenerativeTypeProvider.Provided
open Microsoft.FSharp.Quotations

type Fibo = Provided.TypeProviderFSM<"""[{"currentState": 1 , "localRole": "A" , "partner": "C" , "label": "No" , "payload": [] , "type": "choice" , "nextState": 16 },{"currentState": 16 , "localRole": "A" , "partner": "S" , "label": "No" , "payload": [] , "type": "send" , "nextState": 14 },{"currentState": 14 , "localRole": "A" , "partner": "C" , "label": "Bye" , "payload": [] , "type": "receive" , "nextState": 2 },{"currentState": 1 , "localRole": "A" , "partner": "C" , "label": "Yes" , "payload": [] , "type": "choice" , "nextState": 15 },{"currentState": 15 , "localRole": "A" , "partner": "S" , "label": "Yes" , "payload": [] , "type": "send" , "nextState": 14 },{"currentState": 1 , "localRole": "A" , "partner": "C" , "label": "Query" , "payload": ["System.String"] , "type": "choice" , "nextState": 13 },{"currentState": 13 , "localRole": "A" , "partner": "C" , "label": "Quote" , "payload": ["System.Int32"] , "type": "send" , "nextState": 12 },{"currentState": 12 , "localRole": "A" , "partner": "S" , "label": "truc" , "payload": [] , "type": "send" , "nextState": 3 },{"currentState": 3 , "localRole": "A" , "partner": "C" , "label": "No" , "payload": [] , "type": "choice" , "nextState": 11 },{"currentState": 11 , "localRole": "A" , "partner": "S" , "label": "No" , "payload": [] , "type": "send" , "nextState": 9 },{"currentState": 9 , "localRole": "A" , "partner": "C" , "label": "Bye" , "payload": [] , "type": "receive" , "nextState": 2 },{"currentState": 3 , "localRole": "A" , "partner": "C" , "label": "Yes" , "payload": [] , "type": "choice" , "nextState": 10 },{"currentState": 10 , "localRole": "A" , "partner": "S" , "label": "Yes" , "payload": [] , "type": "send" , "nextState": 9 },{"currentState": 3 , "localRole": "A" , "partner": "C" , "label": "Query" , "payload": ["System.String"] , "type": "choice" , "nextState": 8 },{"currentState": 8 , "localRole": "A" , "partner": "C" , "label": "Quote" , "payload": ["System.Int32"] , "type": "send" , "nextState": 7 },{"currentState": 7 , "localRole": "A" , "partner": "S" , "label": "truc" , "payload": [] , "type": "send" , "nextState": 3 }]""","Examples/Fibonacci/config.yaml">
    //let test = new Test()
(*type Test = Provided.TypeProvider<""" 
  [ { "currentState":1 , "localRole":"Me", "partner":"You" , "label":"Hello()" , "type":"send" , "nextState": 5},
    { "currentState":1 , "localRole":"Me", "partner":"You" , "label":"Naaa()" , "type":"send" , "nextState": 5},
    { "currentState":5 , "localRole":"Me", "partner":"You" , "label":"GoodMorning()" , "type":"choice" , "nextState":4  },
    { "currentState":5 , "localRole":"Me", "partner":"You" , "label":"Bye()" , "type":"choice" , "nextState":3  },
    { "currentState":4 , "localRole":"Me", "partner":"You" , "label":"ThankYou()", "type":"send" , "nextState":2 },
    { "currentState":3 , "localRole":"Me", "partner":"You" , "label":"YouToo()" , "type":"send" , "nextState":2  },
    { "currentState":2 , "localRole":"Me", "partner":"You" , "label":"Stop()" , "type":"send" , "nextState":6  } ] """>
    *)
//let buf = new TypeGeneration.Buf<int>()
//let c = test.Start()
//let d = c.send(new Test.Hello(),Test.You.instance).branch() .receive(new Test.GoodMorning(),Test.You.instance,buf).send(new Test.Bye(),Test.You.instance,buf.  //.branch() //.receive(new Test.GoodMorning(),Test.You.instance).send(new Test.Bye(), Test.You.instance)

(*type Test = Provided.TypeProvider<""" 
  [ { "currentState":1 , "localRole":"Me", "partner":"You" , "label":"Hello()" , "payload" : ["System.Int32","System.String"] , "type":"send" , "nextState": 5},
    { "currentState":5 , "localRole":"Me", "partner":"You" , "label":"GoodMornin()" , "payload" : ["System.Int32"] , "type":"choice" , "nextState": 4},
    { "currentState":5 , "localRole":"Me", "partner":"You" , "label":"GoodNight()" , "payload" : ["System.Int32"] , "type":"choice" , "nextState": 4},
    { "currentState":5 , "localRole":"Me", "partner":"You" , "label":"STUFf()" , "payload" : ["System.Int32"] , "type":"choice" , "nextState": 4},
    { "currentState":4 , "localRole":"Me", "partner":"You" , "label":"Bye()", "payload" : ["System.String"] , "type":"send" , "nextState":3  },
    { "currentState":4 , "localRole":"Me", "partner":"You" , "label":"No()", "payload" : ["System.Int32"] , "type":"send" , "nextState":6  } ] """>*)
(*
let array = System.BitConverter.GetBytes(5)
let elemType = "System.Int32"
let sub = elemType.Split('.')
let typing = sub.[sub.Length-1]
System.BitConverter.ToString(array,0)
let fo = Type.GetType("System.BitConverter")
             .GetMethod("To"+typing,[|typeof<byte []>;typeof<int>|])
             .Invoke(null,[|box array;box 0|])*)


//let truc = Test.You.instance

let test = new Autre()
let c = test.Start()

let a = new DomainModel.Buf<int>()
let b = new DomainModel.Buf<float>()
let d = c.sendHello(Autre.You.instance).branch()// .send(new Autre.Hello(),Autre.You.instance) .receiveAsync(new Autre.GoodMorning(),Autre.You.instance,a).send(new Autre.Bye(),Autre.You.instance,a.getValue())

match d with
    | :? Autre.Bye as bye -> bye.receive(a).finish() .send(new Test.No(),Test.You.instance,a.getValue()).finish()
    | _ -> 
let d = c.send(new Autre.Hello(),Autre.You.instance).receiveAsync(new Autre.GoodMorning(),Autre.You.instance,a).send(new Autre.Bye(),Autre.You.instance,a.getValue())
//let d = c.send(new Test.Hello(),Test.You.instance,23,"hey you").branch() //.receive(new Test.GoodMornin(),Test.You.instance,a).send(new Test.Bye(),Test.You.instance,a.getValue())
//d.finish()
a.getValue()
let truc = new Test.State4()






let receive() =
    let read = Console.ReadLine()
    match read with
        |"hey" -> (new Test.GoodMornin() :> Test.Choice1)
        |_ -> (new Test.GoodNight() :> Test.Choice1)

let x = receive()

match x with
    | :? Test.GoodMornin as gm -> "GoodMornin HEY" + gm.next().send(new Test.Bye(),Test.You.instance,"he")
    | :? Test.GoodNight as gn -> "GoodNight Hooo" + gn.ToString()
    | _ -> "TEMPIS"



match d with 
    | :? Test.GoodMornin as e -> "Hey" //e. .send(new Test.Thankyou())
    | :? Test.GoodNight -> " Almost but No "
    | _ -> " NOOOOO "



open System

type Base = interface end
type Base1 = interface end

type A() = 
    interface Base
    interface Base1
    member __.resultA = "A"

type B() =
    interface Base
    member __.resultB = "B"

type C() =
    interface Base1
    member __.resultC = "C"

let receive1() =
    let read = Console.ReadLine()
    match read with
        |"hey" -> (new B() :> Base)
        |_ -> (new A() :> Base)

let x = receive1()


match x with
    | :? A as a -> a.resultA
    | :? B as b -> b.resultB
    | _ -> "TEMPIS"


let receive2() =
    let read = Console.ReadLine()
    match read with
        |"hey" -> (new C() :> Base1)
        |_ -> (new A() :> Base1)

let y = receive2()

match y with
    | :? A as a -> a.resultA
    | :? C as c -> c.resultC
    | _ -> "TEMPIS"

let n = 1

let s = seq {for i in 1..n do 
                yield "type Choice" + i.ToString() + "() = class end" + "\n" }

let outFile = new System.IO.StreamWriter("../../../test.fsx")

let test = s |> Seq.iter (fun x -> x |> outFile.WriteLine)
let size = s |> Seq.fold(fun acc x -> Array.append acc (System.Text.ASCIIEncoding.ASCII.GetBytes(x))) [||]
             |> Array.length


outFile.Flush()