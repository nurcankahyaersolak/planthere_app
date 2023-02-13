const router = require('express').Router()

const categoryController = require('../Controllers/CategoryController')

const { AsyncHandler } = require('../Middlewares/CustomExceptionHandler')
const AuthenticationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const AuthorizationMiddleware = require('../../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')
const setRole = require('./SetRole')

router.get('/', categoryController.getCategories)
router.get('/:id', AsyncHandler(categoryController.getCategoryById))
router.post('/', setRole(["seller", "superadmin"]), [AuthenticationMiddleware, AuthorizationMiddleware], AsyncHandler(categoryController.createCategory))
router.put('/', setRole(['superadmin']), [AuthenticationMiddleware, AuthorizationMiddleware], AsyncHandler(categoryController.updateCategory))
router.delete('/', setRole(['superadmin']), [AuthenticationMiddleware, AuthorizationMiddleware], AsyncHandler(categoryController.deleteCategory))

module.exports = router;