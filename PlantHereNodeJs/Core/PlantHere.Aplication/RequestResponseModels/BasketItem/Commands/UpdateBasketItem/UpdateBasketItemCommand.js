const Guid = require("../../../../../PlantHere.Aplication/Services/GuidService")

class UpdateBasketItemCommand{
    constructor(productId,userId,count) {
        this.UserId = userId,
        this.ProductId = productId,
        this.Count = count
        this.UpdatedDate = Guid.dateNow(); 
    }
}

module.exports =  {UpdateBasketItemCommand}