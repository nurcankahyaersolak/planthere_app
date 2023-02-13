const { GetOrdersByUserIdQueryResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Order/Queries/GetOrdersByUserId/GetOrdersByUserIdQueryResult")
const { AddressQueryResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Address/Queries/AddressQueryResult")
const {GetBasketItemQuery} = require('../RequestResponseModels/BasketItem/Queries/GetBasketItems/GetBasketItemQuery') 

const Mapper = (result) => {
    if (Array.isArray(result)) {
        returnArray = []
        result.forEach(element => {

            orderItemsDto = []

            element.OrderItems.forEach(basketItem => {
                const baketItemDto = new GetBasketItemQuery(basketItem.Id, basketItem.ProductId,
                    basketItem.ProductName,
                    basketItem.Price,
                    basketItem.DiscountedPrice,
                    basketItem.Count)
                    orderItemsDto.push(baketItemDto)
            });

            const adress = new AddressQueryResult(element.Address_Province, element.Address_District, element.Address_Street, element.Address_ZipCode, element.Address_Line)
            const resultDTO = new GetOrdersByUserIdQueryResult(element.Id, element.CreatedDate, adress, element.BuyerId, orderItemsDto)
            returnArray.push(resultDTO)
        });
        return returnArray;
    }
    const adress = new AddressQueryResult(result.Address_Province, result.Address_District, result.Address_Street, result.Address_ZipCode, result.Address_Line)
    return new GetOrdersByUserIdQueryResult(result.CreatedDate, adress, result.BuyerId, result.OrderItems)
}


module.exports = { Mapper }