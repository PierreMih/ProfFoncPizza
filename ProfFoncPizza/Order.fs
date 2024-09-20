namespace ProfFoncPizza

open System
open ProfFoncPizza.Types

type Order = {
    Id : Guid
    OrderedAt : DateTime
    ReadyAt : DateTime
    OrderType : string
    Status : string
    Amount : int
    TotalAmount : int
    Items : PizzaInOrder list
    DeliveryCosts : int
}
    

    // {
    //     "id": "1b50f90d-cd69-4db8-8563-fa7e06cb87db",
    //     "orderedAt": "2024-09-15 20:40:00",
    //     "readyAt": "2024-09-15 20:51:00",
    //     "orderType": "Delivery",
    //     "status": "Completed",
    //     "amount": 14,
    //     "totalAmount": 23,
    //     "items": [
    //         {
    //             "pizzaId": "d088b172-ec12-44c9-8ca2-1d7096204316",
    //             "quantity": 2,
    //             "price": 7,
    //             "amount": 14
    //         }
    //     ],
    //     "deliveryCosts": 9
    // },