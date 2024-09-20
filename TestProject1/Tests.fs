namespace TestProject1

open System
open System.Collections
open Microsoft.VisualStudio.TestTools.UnitTesting
open ProfFoncPizza
open ProfFoncPizza.MyPizzas
open ProfFoncPizza.Types
open System.Linq

[<TestClass>]
type TestClass () =
        
    [<TestMethod>]
    member this.aCanReadPizzasJson () =
        let pizzaStream = OpenPizzaJsonFile
        Assert.IsTrue(pizzaStream().CanRead)
    
    [<TestMethod>]
    member this.bCanReadPizzasFromJson () =
        let pizzaList = GetPizzaListFromJson()
        Assert.IsTrue(pizzaList |> List.length > 0)
        Assert.IsTrue(pizzaList.Any(fun p -> p.Name = "Quattro Stagioni"))
        
    [<TestMethod>]
    member this.cCanReadOrdersJson () =
        let ordersStream = OpenOrderJsonFile()
        Assert.IsTrue(ordersStream.CanRead)
        
    [<TestMethod>]
    member this.dCanReadOrdersFromJson () =
        let orderList = GetOrderListFromJson()
        Assert.IsTrue(orderList |> List.length > 0)
        Assert.IsTrue(orderList.Any(fun o -> o.Id = Guid.Parse("1b50f90d-cd69-4db8-8563-fa7e06cb87db")))
        
    [<TestMethod>]
    member this.eCanReadOrdersWithPizzasFromJson () =
        let orderList = GetOrderListFromJson()
        Assert.IsTrue(orderList |> List.length > 0)
        Assert.IsTrue(orderList.Any(fun o -> o.Id = Guid.Parse("1b50f90d-cd69-4db8-8563-fa7e06cb87db")))
        let pizzaIdsOrdered = orderList.SelectMany(fun o -> o.Items.AsEnumerable())
        Assert.IsTrue(pizzaIdsOrdered.All(fun pio -> pio.PizzaId <> Guid.Empty))
    
    [<TestMethod>]
    member this.fCountBases () =
        let bases = GetDifferentBases()
        for b in bases.Select(fun b->b.Name) do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {bases.Count()}")
        Assert.IsTrue(bases.Count() > 0)
    
    [<TestMethod>]
    member this.gCountBaseTomate () =
        let pizzasBaseTomate = GetPizzasBaseTomate()
        for b in pizzasBaseTomate.Select(fun b->b.Name) do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {pizzasBaseTomate.Count()}")
        Assert.IsTrue(pizzasBaseTomate.Count() > 0)
    
    [<TestMethod>]
    member this.hCountDifferentIngredients () =
        let differentIngredients = GetDifferentIngredients()
        for b in differentIngredients do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {differentIngredients.Count()}")
        Assert.IsTrue(differentIngredients.Count() > 0)
    
    [<TestMethod>]
    member this.iWhichIngredientsInOnlyOnceRecipe () =
        let ingredients = GetIngredientsUsedOnlyOnce()
        for b in ingredients do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {ingredients.Count()}")
        Assert.IsTrue(ingredients.Count() > 0)    
    
    [<TestMethod>]
    member this.jPizzasWithLessThan4Ingredients () =
        let pizzas = GetPizzasWithLessThan4Ingredients()
        for b in pizzas do
            Console.WriteLine(b.Name)
        Console.WriteLine($"Réponse : {pizzas.Count()}")
        Assert.IsTrue(pizzas.Count() > 0)
        
    [<TestMethod>]
    member this.kPizzasNeverSold () =
        let pizzas = GetPizzasThatWereNeverSold()
        for b in pizzas do
            Console.WriteLine(b.Name)
        Console.WriteLine($"Réponse : {pizzas.Count()}")
        Assert.IsTrue(pizzas.Count() > 0)
        
    [<TestMethod>]
    member this.lOrderAveragePrice () =
        let average = GetPrixDesCommandesDePizza()
        Console.WriteLine($"Réponse : {average}")
        Assert.IsTrue(average > 0)
        
    [<TestMethod>]
    member this.mPizzaTomateAveragePrice () =
        let average = GetPrixMoyenPizzaTomate()
        Console.WriteLine($"Réponse : {average}")
        Assert.IsTrue(average > 0)
        
    [<TestMethod>]
    member this.nPizzasWithoutMeat () =
        let pizzas = GetPizzaRecipesWithNoMeat()
        for b in pizzas do
            Console.WriteLine(b.Name)
        Console.WriteLine($"Réponse : {pizzas.Count()}")
        Assert.IsTrue(pizzas.Count() > 0)
        
    [<TestMethod>]
    member this.oPizzaLaPlusVendue () =
        let pizza = GetPizzaLaPlusVendue()
        Console.WriteLine($"Réponse : {(fst pizza).Name} en {snd pizza} exemplaires")
        Assert.IsTrue((fst pizza).Id <> Guid.Empty && snd pizza > 0)
        
    [<TestMethod>]
    member this.pMoyenneNbPizzasParCommande () =
        let nb = GetNbMoyenPizzasParCommande()
        Console.WriteLine($"Réponse : {nb}")
        Assert.IsTrue(nb > 0)
    
    [<TestMethod>]
    member this.qUnusedIngredients () =
        let pizzas = GetUnusedIngredients()
        for b in pizzas do
            Console.WriteLine(b)
        Console.WriteLine($"Réponse : {pizzas.Count()}")
        Assert.IsTrue(pizzas.Count() > 0)
        
    [<TestMethod>]
    member this.rPizzasOrderedOnlyOnce () =
        let pizzas = GetPizzasOrderedOnlyOnce()
        for b in pizzas do
            Console.WriteLine($"{snd b} {(fst b).Name}")
        Console.WriteLine($"Réponse : {pizzas.Count()}")
        Assert.IsTrue(pizzas.Count() > 0)
        
    [<TestMethod>]
    member this.sMoyenneMinutesTempsPreparation () =
        let nb = GetNbMoyenPizzasParCommande()
        Console.WriteLine($"Réponse : {nb}")
        Assert.IsTrue(nb > 0)
    
    