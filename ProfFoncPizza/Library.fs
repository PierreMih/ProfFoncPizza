namespace ProfFoncPizza

open System.Collections.Generic
open System.IO
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
    
    let IngredientsUsedOnlyOnce () =
        let pizzaList = GetPizzaListFromJson()
        pizzaList
            |> _.SelectMany(fun p -> p.Ingredients :>IEnumerable<_>)
            |> _.GroupBy(fun i -> i)
            |> _.Select(fun o -> (o.Key, o.Count()))
            |> _.Where(fun t -> snd t = 1)
            |> _.Select(fst) 
    