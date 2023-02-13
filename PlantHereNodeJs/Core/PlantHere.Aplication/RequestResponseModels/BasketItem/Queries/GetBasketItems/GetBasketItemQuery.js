class GetBasketItemQuery{

    constructor(id,productId,productName,price,discountedPrice,count) {
        this.id =id 
        this.productId = productId,
        this.productName = productName, 
        this.price = price,
        this.discountedPrice = discountedPrice,
        this.count = count
    }
}

module.exports = {GetBasketItemQuery}
