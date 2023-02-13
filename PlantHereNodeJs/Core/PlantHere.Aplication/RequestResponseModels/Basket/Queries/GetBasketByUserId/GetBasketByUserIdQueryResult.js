class GetBasketByUserIdQueryResult {
    constructor(createdDate,userId,basketItems) {
        this.userId = userId,
        this.createdDate = createdDate,
        this.basketItems = basketItems
        this.totalPrice = basketItems.reduce((acc, o) => acc + o.price * o.count, 0)
        this.discountedTotalPrice = basketItems.reduce((acc, o) => acc + o.discountedPrice * o.count, 0)
    }
}

module.exports = { GetBasketByUserIdQueryResult } 