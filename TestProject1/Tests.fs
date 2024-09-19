namespace TestProject1

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open ProfFoncPizza.MyPizzas
open ProfFoncPizza.Types
open System.Linq

[<TestClass>]
type TestClass () =
        
    [<TestMethod>]
    member this.CanReadPizzasJson () =
        let pizzaStream = OpenPizzaJsonFile
        Assert.IsTrue(pizzaStream.CanRead)
    
    [<TestMethod>]
    member this.CanReadPizzasFromJson () =
        let pizzaList = GetPizzaListFromJson
        Assert.IsTrue(pizzaList |> List.length > 0)
        Assert.IsTrue(pizzaList.Any(fun p -> p.Name = "Quattro Stagioni"))
        
    [<TestMethod>]
    member this.CanReadOrdersJson () =
        let ordersStream = OpenOrderJsonFile
        Assert.IsTrue(ordersStream.CanRead)
        
    [<TestMethod>]
    member this.CanReadOrdersFromJson () =
        let orderList = GetOrderListFromJson
        Assert.IsTrue(orderList |> List.length > 0)
        Assert.IsTrue(orderList.Any(fun o -> o.Id = Guid.Parse("1b50f90d-cd69-4db8-8563-fa7e06cb87db")))