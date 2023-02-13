const router = require('express').Router()
const basketController = require('../Controllers/BasketController')

const { AsyncHandler } = require('../Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.get('/',setRole(["customer"]),[AuthenticationMiddleware,AuthorizationMiddleware], AsyncHandler(basketController.getBasketByUserId))
router.post('/BuyBasket',setRole(["customer","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], AsyncHandler(basketController.buyBasket))

module.exports = router;