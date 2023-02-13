class GetBasketItemQuery{

    constructor(productId,productName,price,discountedPrice,count) {
        this.productId = productId,
        this.productName = productName, 
        this.price = price,
        this.discountedPrice = discountedPrice,
        this.count = count
    }
}

module.exports = {GetBasketItemQuery}
