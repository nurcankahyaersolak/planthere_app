class GetOrdersByUserIdQueryResult{

    constructor(id,createdDate,address,buyerId,orderItems) {
        this.id = id,
        this.createdDate = createdDate,
        this.address = address,
        this.buyerId = buyerId,
        this.orderItems = orderItems,
        this.totalPrice = orderItems.reduce((acc, o) => acc + o.price * o.count, 0),
        this.discountedTotalPrice = orderItems.reduce((acc, o) => acc + o.discountedPrice * o.count, 0)
    }
}

module.exports = { GetOrdersByUserIdQueryResult }