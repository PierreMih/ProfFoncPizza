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
        Assert.IsTrue(pizzaStream().CanRead)
    
    [<TestMethod>]
    member this.CanReadPizzasFromJson () =
        let pizzaList = GetPizzaListFromJson()
        Assert.IsTrue(pizzaList |> List.length > 0)
        Assert.IsTrue(pizzaList.Any(fun p -> p.Name = "Quattro Stagioni"))
        
    [<TestMethod>]
    member this.CanReadOrdersJson () =
        let ordersStream = OpenOrderJsonFile()
        Assert.IsTrue(ordersStream.CanRead)
        
    [<TestMethod>]
    member this.CanReadOrdersFromJson () =
        let orderList = GetOrderListFromJson()
        Assert.IsTrue(orderList |> List.length > 0)
        Assert.IsTrue(orderList.Any(fun o -> o.Id = Guid.Parse("1b50f90d-cd69-4db8-8563-fa7e06cb87db")))
    
    [<TestMethod>]
    member this.CountBases () =
        let bases = GetDifferentBases()
        for b in bases.Select(fun b->b.Name) do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {bases.Count()}")
        Assert.IsTrue(bases.Count() > 0)
    
    [<TestMethod>]
    member this.CountBaseTomate () =
        let pizzasBaseTomate = GetPizzasBaseTomate()
        for b in pizzasBaseTomate.Select(fun b->b.Name) do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {pizzasBaseTomate.Count()}")
        Assert.IsTrue(pizzasBaseTomate.Count() > 0)
    
    [<TestMethod>]
    member this.CountDifferentIngredients () =
        let differentIngredients = GetDifferentIngredients()
        for b in differentIngredients do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {differentIngredients.Count()}")
        Assert.IsTrue(differentIngredients.Count() > 0)
    
    [<TestMethod>]
    member this.WhichIngredientsInOnlyOnceRecipe () =
        let ingredients = IngredientsUsedOnlyOnce()
        for b in ingredients do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {ingredients.Count()}")
        Assert.IsTrue(ingredients.Count() > 0)