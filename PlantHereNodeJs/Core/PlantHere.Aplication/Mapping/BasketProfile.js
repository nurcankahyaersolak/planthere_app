const {GetBasketItemQuery} = require('../RequestResponseModels/BasketItem/Queries/GetBasketItems/GetBasketItemQuery') 
const {GetBasketByUserIdQueryResult} = require('../RequestResponseModels/Basket/Queries/GetBasketByUserId/GetBasketByUserIdQueryResult')

const Mapper = (value, classes) => {
    basketItemsDto = []

    value.BasketItems.forEach(basketItem => {
        const baketItemDto = new GetBasketItemQuery(basketItem.Id,basketItem.ProductId,
            basketItem.ProductName,
            basketItem.Price,
            basketItem.DiscountedPrice,
            basketItem.Count)        
        basketItemsDto.push(baketItemDto)
    });

    return  new classes(value.CreatedDate,value.UserId,basketItemsDto)
}

module.exports = { Mapper }
