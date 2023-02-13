const Guid = require("../../../../../PlantHere.Aplication/Services/GuidService")

class CreateBasketItemCommand{
    constructor(productId,userId,productName,price,discountedPrice) {
        this.ProductId = productId,
        this.UserId = userId,
        this.ProductName = productName,
        this.Price = price,
        this.DiscountedPrice = discountedPrice,
        this.UniqueId  = Guid.createGuid(),
        this.CreatedDate =  Guid.dateNow(); 
        this.UpdatedDate = Guid.dateNow(); 
    }
}

module.exports =  {CreateBasketItemCommand}