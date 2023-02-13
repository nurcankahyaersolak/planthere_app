// Interface - Service

const Interface = require("es6-interface");
const { IOrderService } = require('../../../Core/PlantHere.Aplication/Interfaces/Services/IOrderService')

// RequestResponseModels
const { CreateOrderCommand } = require("../../PlantHere.Aplication/RequestResponseModels/Order/Commands/CreateOrder/CreateOrderCommand")
const { CreateOrderItemCommand } = require('../../../Core/PlantHere.Aplication/RequestResponseModels/OrderItem/Commands/CreateOrderItem/CreateOrderItemCommand')
// Db
const db = require('../../../Infrastructure/PlantHere.Persistance/AppDbContext');
const { Repository } = require("../../../Infrastructure/PlantHere.Persistance/Repositories/Repository");

// Mapper
const { Mapper } = require('../../../Core/PlantHere.Aplication/Mapping/OrderProfile');

class OrderService extends Interface(IOrderService)
{
    constructor() {
        super()
        this.repository = new Repository(db.Orders);
        this.orderItemRepository = new Repository(db.OrderItems)
    }

    async getOrdersByUserId(getOrdersByUserId) {
        const result = await this.repository.get(["Id", "CreatedDate", "Address_Province", "Address_District", "Address_Street", "Address_ZipCode", "Address_Line", "BuyerId"], { BuyerId: getOrdersByUserId.UserId }, undefined, undefined, db.OrderItems, ['ProductId', 'ProductName', 'Price', 'DiscountedPrice', 'Count'])
        return Mapper(result)
    }

    async getOrderItemsId() {

        const ordersItem = await db.OrderItems.findOne({
            order: [
                ['id', 'DESC']],
            attributes: ['Id']
        })

        if (ordersItem) {
            return ordersItem.Id + 1
        }
        else {
            return 1
        }
    }

    async createOrderAndOrderItem(req, basket) {

        const order = new CreateOrderCommand(req.Address, req.UserId, basket.BasketItems)
        const orderResult = await this.repository.create(order)

        let id = await this.getOrderItemsId();

        basket.BasketItems.forEach(basketItem => {

            const orderItem = new CreateOrderItemCommand(id, basketItem.ProductId, basketItem.ProductName, basketItem.Price, basketItem.DiscountedPrice, basketItem.Count)
            orderItem.OrderId = orderResult.Id
            this.orderItemRepository.create(orderItem)

            basketItem.destroy()

            id += 1;
        });

        return orderResult
    }

}

module.exports = { OrderService }