const Guid = require("../../../../Services/GuidService")

class CreateProductCommand {

    constructor(name,description,price,sellerId,categoryId,discount,stock) {
        this.Name = name,
        this.Description = description,
        this.Price = price,
        this.SellerId = sellerId,
        this.CategoryId = categoryId,
        this.Discount = discount   
        this.Stock = stock
        this.UniqueId  = Guid.createGuid()
        this.CreatedDate =  Guid.dateNow(); 
        this.UpdatedDate = Guid.dateNow();
    }
}

module.exports = {CreateProductCommand}