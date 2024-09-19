namespace TestProject1

open System
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =
        
    [<TestMethod>]
    member this.CanOpenPizzaJson () =
        Assert.IsTrue(true);