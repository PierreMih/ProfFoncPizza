namespace ProfFoncPizza

open System.IO
open System.Text.Json
open System.Text.Json.Nodes
open ProfFoncPizza.Types

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
        JsonSerializer.Deserialize<Order list>(OpenOrderJsonFile(), options)