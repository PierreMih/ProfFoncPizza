namespace ProfFoncPizza

open System.Collections.Generic
open System.IO
open System.Runtime.InteropServices.JavaScript
open System.Text.Json
open System.Text.Json.Nodes
open ProfFoncPizza.CustomDateConverter
open ProfFoncPizza.Types
open System.Linq

module MyPizzas =
    let OpenPizzaJsonFile () =
        File.OpenRead "./data/pizzas.json"
        
    let GetPizzaListFromJson () =
        let pizzaStream = OpenPizzaJsonFile
        let options = JsonSerializerOptions(PropertyNameCaseInsensitive = true)
        JsonSerializer.Deserialize<Pizza list>(pizzaStream(), options)

    let OpenOrderJsonFile () =
        File.OpenRead "./data/orders.json"
    
    let GetOrderListFromJson () =
        let options = JsonSerializerOptions(PropertyNameCaseInsensitive = true)
        options.Converters.Add(CustomDateTimeConverter())  
        JsonSerializer.Deserialize<Order list>(OpenOrderJsonFile(), options)
        
    let GetDifferentBases () =
        let pizzaList = GetPizzaListFromJson()
        pizzaList
            |> _.DistinctBy(fun p -> p.Base)
        
    let GetPizzasBaseTomate () =
        let pizzaList = GetPizzaListFromJson()
        pizzaList
            |> _.Where(fun p -> p.Base = "Tomate")
        
    let GetDifferentIngredients () =
        let pizzaList = GetPizzaListFromJson()
        pizzaList
            |> _.SelectMany(fun p-> p.Ingredients :> IEnumerable<_>) 
            |> _.Distinct()
    
    let GetIngredientsUsedOnlyOnce () =
        let pizzaList = GetPizzaListFromJson()
        pizzaList
            |> _.SelectMany(fun p -> p.Ingredients :>IEnumerable<_>)
            |> _.GroupBy(fun i -> i)
            |> _.Select(fun o -> (o.Key, o.Count()))
            |> _.Where(fun t -> snd t = 1)
            |> _.Select(fst) 
    
    let GetPizzasWithLessThan4Ingredients () =
        GetPizzaListFromJson()
            |> _.Where(fun p -> p.Ingredients.Count() < 4)
        
    let GetPizzasThatWereNeverSold () =
        let pizzaList = GetPizzaListFromJson()
        let orderList = GetOrderListFromJson()
        let orderedPizzas = orderList
                                .SelectMany(fun o -> o.Items.DistinctBy(fun pio -> pio.PizzaId) :> IEnumerable<_>)
                                .Join(pizzaList, (fun pio -> pio.PizzaId), (fun p -> p.Id), fun pio p -> p)
        pizzaList.Except(orderedPizzas)
        
    let GetPrixDesCommandesDePizza () =
        let orderList = GetOrderListFromJson()
        orderList.Average(fun o -> o.TotalAmount)
        
    let GetPrixMoyenPizzaTomate () =
        let pizzaList = GetPizzaListFromJson()
        pizzaList.Where(fun p -> p.Base = "Tomate")
            .Average(fun p -> p.Price)
    
    let GetPizzaRecipesWithNoMeat () =
        let pizzaList = GetPizzaListFromJson()
        pizzaList.Where(fun p -> not(p.Ingredients.Intersect(["Anchois"; "Jambon Cru"; "Saucisson Piquant"; "Jambon Cuît"]).Any()))
        
    let GetPizzaLaPlusVendue () =
        let orderList = GetOrderListFromJson()
        let guidPizzaInOrderLaPlusVendueWithQuantity = orderList
                                                           .SelectMany(fun o -> o.Items :> IEnumerable<_>)
                                                           .Select(fun pio -> (pio.PizzaId, pio.Quantity))
                                                           .GroupBy(fun tup -> fst tup)
                                                           .Select(fun tup -> tup.Key, tup.Sum(snd) )
                                                           .OrderByDescending(snd)
                                                           .First()
        let pizzaList = GetPizzaListFromJson()
        (pizzaList.First(fun p -> p.Id = fst guidPizzaInOrderLaPlusVendueWithQuantity), snd guidPizzaInOrderLaPlusVendueWithQuantity)
        
    let GetNbMoyenPizzasParCommande () =
        let orderList = GetOrderListFromJson()
        orderList.Average(fun o -> o.Items.Count())
        
    let GetUnusedIngredients () =
        let orderList = GetOrderListFromJson()
        let pizzaList = GetPizzaListFromJson()
        let orderedPizzas = orderList
                                .SelectMany(fun o -> o.Items :> IEnumerable<_>)
                                .Distinct()
                                .Join(pizzaList, (fun pio -> pio.PizzaId), (fun p -> p.Id), fun pio p -> p)
        let usedIngredients = orderedPizzas
                                    .SelectMany(fun p -> p.Ingredients :> IEnumerable<_>)
                                    .Distinct()
        let ingredients = pizzaList
                                    .SelectMany(fun p -> p.Ingredients :> IEnumerable<_>)
                                    .Distinct()
        ingredients.Except(usedIngredients)
        
    