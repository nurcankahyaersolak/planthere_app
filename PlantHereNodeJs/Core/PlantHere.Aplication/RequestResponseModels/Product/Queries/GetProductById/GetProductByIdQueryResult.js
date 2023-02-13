class GetProductByIdQueryResult {
    constructor(name, description, discount, price, uniqueId,images) {
        this.name = name,
        this.description = description,
        this.discount = discount,
        this.price = price,
        this.discountedPrice = (price - (price * discount)/100),
        this.uniqueId = uniqueId
        this.images = images
      }
}

module.exports = { GetProductByIdQueryResult } 