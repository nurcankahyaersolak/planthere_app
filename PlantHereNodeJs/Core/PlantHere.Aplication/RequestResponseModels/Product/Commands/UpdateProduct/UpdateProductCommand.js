const Guid = require("../../../../Services/GuidService")

class UpdateProductCommand {

    constructor(id,name,description,price,sellerId,categoryId,discount) {
        this.Id = id,
        this.Name = name,
        this.Description = description,
        this.Price = price,
        this.SellerId = sellerId,
        this.CategoryId = categoryId,
        this.Discount = discount,
        this.UpdatedDate = Guid.dateNow();  
    }
}

module.exports = {UpdateProductCommand}