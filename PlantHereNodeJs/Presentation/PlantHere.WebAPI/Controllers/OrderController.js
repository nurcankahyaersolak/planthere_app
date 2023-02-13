//  SERVICE
const OrderService = require('../../../Core/PlantHere.Aplication/Services/OrderService').OrderService

const {GetOrdersByUserIdQuery} = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Order/Queries/GetOrdersByUserId/GetOrdersByUserIdQuery")

const service = new OrderService();

//Results
const { CustomResult } = require('../Results/CustomResult')



const getOrdersByUserId = async (req, res) => {
    res.json(CustomResult.Success(await service.getOrdersByUserId(new GetOrdersByUserIdQuery(req.userId))))
}

module.exports = {
    getOrdersByUserId
}



