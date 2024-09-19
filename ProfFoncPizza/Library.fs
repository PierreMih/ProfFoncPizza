namespace ProfFoncPizza

open System.IO
open System.Text.Json
open System.Text.Json.Nodes
open ProfFoncPizza.Types

module MyPizzas =
    let openPizzaJsonFile =
        File.OpenRead "ProfFoncPizza/data/pizzas.json"
        
    // let loadPizzaStreamToJson =
    //     let pizzaStream = openPizzaJsonFile
    //     JsonObject.Parse pizzaStream
        
    let deserializeStreamToPizza =
        let pizzaStream = openPizzaJsonFile
        JsonSerializer.Deserialize<Pizza list> pizzaStream
