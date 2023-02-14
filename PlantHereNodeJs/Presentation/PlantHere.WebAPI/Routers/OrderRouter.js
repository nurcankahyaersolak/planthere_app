const router = require('express').Router()
const OrderController = require('../Controllers/OrderController')

const { AsyncHandler } = require('../Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.get('/',setRole(["superadmin","customer"]),[AuthenticationMiddleware,AuthorizationMiddleware],AsyncHandler(OrderController.getOrdersByUserId))

module.exports = router;