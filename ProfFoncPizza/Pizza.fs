namespace ProfFoncPizza.Types

open System

type Pizza = {
    Id: Guid
    Name: string
    Price: int
    Base: string
    Ingredients: string list
}
    
    
    // "id": "1fa92403-d4e0-401a-9a6a-b5450b5cecf2",
    //     "name": "Quattro Stagioni",
    //     "price": 12,
    //     "base": "Tomate",
    //     "ingredients": [
    //         "Mozzarella",
    //         "Jambon Cuît",
    //         "Olives Vertes",
    //         "Coeurs d'Artichaut",
    //         "Champignons"
    //     ]