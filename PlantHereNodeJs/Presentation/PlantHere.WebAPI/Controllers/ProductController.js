//  SERVICE
const ProductService = require('../../../Core/PlantHere.Aplication/Services/ProductService').ProductService


const GetProductsByPageQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsByPage/GetProductsByPageQuery').GetProductsByPageQuery
const GetProductsByCategoryIdAndPageQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductByCategoryIdAndPage/GetProductByCategoryIdAndPageQuery').GetProductsByCategoryIdAndPageQuery
const GetProductByIdQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductById/GetProductByIdQuery').GetProductByIdQuery
const DeleteProductCommand = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/DeleteProduct/DeleteProductCommand').DeleteProductCommand
const UpdateProductCommand = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/UpdateProduct/UpdateProductCommand').UpdateProductCommand
const CreateProductCommand = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/CreateProduct/CreateProductCommand').CreateProductCommand
const GetProductsCountQuery = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsCount/GetProductsCountQuery').GetProductsCountQuery

const service = new ProductService();

//Results
const { CustomResult } = require('../Results/CustomResult')


const getProductsCount = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsCount(new GetProductsCountQuery())))
}

const getProductsByPage = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsByPage(new GetProductsByPageQuery(req.params.page, req.params.pageSize))))
}

const getProductsByCategoryIdAndPage = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsByCategoryIdAndPage(new GetProductsByCategoryIdAndPageQuery(req.body.page, req.body.pageSize), req.params.categoryId)))
}

const getProductById = async (req, res) => {
    res.json(CustomResult.Success(await service.getProductsById(new GetProductByIdQuery(req.params.id))))
}

const deleteProduct = async (req, res) => {
    res.json(CustomResult.Success(await service.deleteProduct(new DeleteProductCommand(req.params.id))))
}

const createProduct = async (req, res) => {
    res.json(CustomResult.Success(await service.createProduct(new CreateProductCommand(req.body.name, req.body.description, req.body.price, req.body.sellerId, req.body.categoryId, req.body.discount, req.body.stock))))
}

const updateProduct = async (req, res) => {
    res.json(CustomResult.Success(await service.updateProduct(new UpdateProductCommand(req.body.id, req.body.name, req.body.description, req.body.price, req.body.sellerId, req.body.categoryId, req.body.discount))))
}

module.exports = {
    getProductsCount,
    getProductsByPage,
    getProductsByCategoryIdAndPage,
    getProductById,
    deleteProduct,
    createProduct,
    updateProduct
}



