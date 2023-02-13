class DeleteBasketItemCommand{
    constructor(userId,productId) {
        this.UserId = userId,
        this.ProductId = productId
    }
}

module.exports =  {DeleteBasketItemCommand}