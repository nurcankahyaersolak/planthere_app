const Guid = require("../../../../../PlantHere.Aplication/Services/GuidService")

class CreateOrderCommand{

    constructor(address,buyerId,orderItems) {
        this.CreatedDate = Guid.dateNow(),
        this.Address_Province = address.province,
        this.Address_District = address.district,
        this.Address_Street = address.street,
        this.Address_ZipCode = address.zipCode,
        this.Address_Line = address.line,
        this.BuyerId = buyerId,
        this.OrderItems = orderItems
    }
}

module.exports = { CreateOrderCommand }