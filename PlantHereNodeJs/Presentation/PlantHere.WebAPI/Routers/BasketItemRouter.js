const router = require('express').Router()
const basketController = require('../Controllers/BasketController')

const { AsyncHandler } = require('../Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.post('/',setRole(["customer","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], AsyncHandler(basketController.createBasketItem))
router.put('/',setRole(["customer","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware],AsyncHandler(basketController.updateBasketItem))
router.delete('/',setRole(["customer","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware],AsyncHandler(basketController.deleteBasketItem))

module.exports = router;