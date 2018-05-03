
open System;
open CoreLibrary

// Consumer class library
MessageHandlers.Handle(RegisterUser("Matthew", "password"))
MessageHandlers.Handle(DeactivateUser("Matthew"))
MessageHandlers.Handle(OpenAccount("0123456789"))


// Define class
type MyClass(a) =
    let field1 = a
    let field2 = "text" 
    do printfn "%d %s" field1 field2
    member this.F input =
        printfn "Field1 %d Field2 %s Input %A" field1 field2 input

let x = "Hello world";
let f(x) = x * x

let my = new MyClass(23)
my.F "input"


// Sequences
let sequence = seq { 0 .. 10 }

for x in sequence do printfn "%d" x

for x in (Seq.map f sequence) do printfn "%d" x

f 11 |> printfn "%d";

let squares = sequence |> Seq.map f

Console.WriteLine(squares)

for x in squares do printfn "%d" x


// Use class
let acc = new Account("Matthew")
printfn "%s" acc.Name

let s = sprintf "%s" acc.Name


// Union types
type Shape =        // define a "union" of alternative structures
| Circle of int 
| Rectangle of int * int
| Polygon of (int * int) list
| Point of (int * int) 

let draw shape =    // define a function "draw" with a shape param
  match shape with
  | Circle radius -> 
      printfn "The circle has a radius of %d" radius
  | Rectangle (height,width) -> 
      printfn "The rectangle is %d high by %d wide" height width
  | Polygon points -> 
      printfn "The polygon is made of these points %A" points
  | _ -> printfn "I don't recognize this shape"

let circle = Circle(10)
let rect = Rectangle(4,5)
let polygon = Polygon( [(1,1); (2,2); (3,3)])
let point = Point(2,3)

[circle; rect; polygon; point] |> List.iter draw


Console.ReadLine();

