const router = require('express').Router()
const productController = require('../Controllers/ProductController')

const { AsyncHandler } = require('../Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')


router.get('/', AsyncHandler(productController.getProducts))
router.get('/:page/:pageSize', AsyncHandler(productController.getProductsByPage))
router.get('/category/:categoryId', AsyncHandler(productController.getProductsByCategoryIdAndPage))
router.get('/count', AsyncHandler(productController.getProductsCount))
router.get('/:id', AsyncHandler(productController.getProductById))

router.post('',setRole(["seller","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], AsyncHandler(productController.createProduct))
router.put('',setRole(["seller","superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], AsyncHandler(productController.updateProduct))
router.delete('/:id',setRole(["superadmin"]),[AuthenticationMiddleware,AuthorizationMiddleware], AsyncHandler(productController.deleteProduct))

module.exports = router;