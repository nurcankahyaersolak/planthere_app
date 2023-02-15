//  SERVICE
const BasketService = require('../../../Core/PlantHere.Aplication/Services/BasketService').BasketService

const { GetBasketByUserIdQuery } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Queries/GetBasketByUserId/GetBasketByUserIdQuery")
const { DeleteBasketItemCommand } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/DeleteBasketItem/DeleteBasketItemCommand")
const { BuyBasketCommand } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Commands/BuyBasket/BuyBasketCommand")
const { CreateBasketItemCommand } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/CreateBasketItem/CreateBasketItemCommand")

const service = new BasketService();

//Results
const { CustomResult } = require('../Results/CustomResult')

const getBasketByUserId = async (req, res) => {
    res.json(CustomResult.Success(await service.getBasketByUserId(new GetBasketByUserIdQuery(req.userId))))
}

const createBasketItem = async (req, res) => {
    res.json(CustomResult.Success(await service.createBasketItem(new CreateBasketItemCommand(req.body.productId,
        req.userId,
        req.body.productName,
        req.body.price,
        req.body.discountedPrice))))
}

const deleteBasketItem = async (req, res) => {
    res.json(CustomResult.Success(await service.deleteBasketItem(new DeleteBasketItemCommand(req.userId, req.body.productId))))
}


const buyBasket = async (req, res) => {
    res.json(CustomResult.Success(await service.buyBasket(new BuyBasketCommand(req.userId,req.body.address))))
}

module.exports = {
    getBasketByUserId,
    buyBasket,
    deleteBasketItem,
    createBasketItem
}



