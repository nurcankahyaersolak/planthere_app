class GetProductsByPageAndCategoryIdQueryResult {
    constructor(name, description, discount, price, uniqueId) {
        this.name = name,
        this.description = description,
        this.discount = discount,
        this.price = price,
        this.discountedPrice = (price - (price * discount) / 100),
        this.uniqueId = uniqueId
    }
}

module.exports = { GetProductsByPageAndCategoryIdQueryResult }