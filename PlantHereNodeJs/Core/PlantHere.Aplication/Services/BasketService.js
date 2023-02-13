// Interface - Service
const Interface = require("es6-interface");
const { IBasketService } = require('../../../Core/PlantHere.Aplication/Interfaces/Services/IBasketService')
const { PaymentService } = require('../../../Infrastructure/PlantHere.Infrastructure/PaymentService')
const { OrderService } = require("../../../Core/PlantHere.Aplication/Services/OrderService")

// Http Error
const CreateError = require('http-errors')

// RequestResponseModels
const { GetBasketByUserIdQueryResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Queries/GetBasketByUserId/GetBasketByUserIdQueryResult")
const { CreateBasketItemCommandResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/CreateBasketItem/CreateBasketItemCommandResult")
const { DeleteBasketItemCommandResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/BasketItem/Commands/DeleteBasketItem/DeleteBasketItemCommandResult")
const { BuyBasketCommandResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Basket/Commands/BuyBasket/BuyBasketComamndResult")

//Repository
const db = require('../../../Infrastructure/PlantHere.Persistance/AppDbContext');
const { Repository } = require("../../../Infrastructure/PlantHere.Persistance/Repositories/Repository");

// Mapper
const { Mapper } = require('../../../Core/PlantHere.Aplication/Mapping/BasketProfile');

class BasketService extends Interface(IBasketService)
{
    constructor() {
        super()
        this.repository = new Repository(db.Baskets)
        this.basketItemsReposioy = new Repository(db.BasketItems)
        this.paymentService = new PaymentService()
        this.OrderService = new OrderService()
    }

    async createBasketItem(createBasketItemCommand) {

        const baskets = await this.repository.get(["Id", "UserId", "CreatedDate"], { UserId: createBasketItemCommand.UserId }, undefined, undefined, db.BasketItems, ["Id", "ProductName", "Count", "Price", "ProductId"])
        const existProducts = baskets[0].BasketItems.filter(x => x.ProductId === createBasketItemCommand.ProductId)

        if (!existProducts[0]) {
            createBasketItemCommand.Count = 1;
            createBasketItemCommand.BasketId = baskets[0].Id;
            await this.basketItemsReposioy.create(createBasketItemCommand)
        }
        else {
            createBasketItemCommand.Count = existProducts[0].Count + 1;
            await this.basketItemsReposioy.update(createBasketItemCommand, ["Id"], { Id: existProducts[0].Id })
        }

        return new CreateBasketItemCommandResult()
    }

    async getBasketByUserId(getBasketByUserIdQuery) {
        const result = await this.repository.get(["Id", "UserId", "CreatedDate"], { UserId: getBasketByUserIdQuery.UserId }, undefined, undefined, db.BasketItems, ['Id', 'ProductId', 'ProductName', 'Price', 'DiscountedPrice', 'Count'])
        return Mapper(result[0], GetBasketByUserIdQueryResult)
    }

    async deleteBasketItem(deleteBasketItemCommand) {
        const baskets = await this.repository.get(["Id", "UserId", "CreatedDate"], { UserId: deleteBasketItemCommand.UserId })
        return new DeleteBasketItemCommandResult(await this.basketItemsReposioy.delete(["Id", "ProductId", "BasketId"], { ProductId: deleteBasketItemCommand.ProductId, BasketId: baskets[0].Id }))
    }

    async buyBasket(buyBasketCommand) {

        const baskets = await this.repository.get(["Id", "UserId", "CreatedDate"], { UserId: buyBasketCommand.UserId }, undefined, undefined, db.BasketItems, ["Id", "ProductName", "Count", "Price","DiscountedPrice" ,"ProductId"])

        if (!baskets[0].BasketItems[0]) {
            throw new CreateError.NotFound()
        }

       return new BuyBasketCommandResult(await this.OrderService.createOrderAndOrderItem(buyBasketCommand,baskets[0]))
    }
}

module.exports = { BasketService }