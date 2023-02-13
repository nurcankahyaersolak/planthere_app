// Interface
const Interface = require("es6-interface");
const IProductService = require('../../../Core/PlantHere.Aplication/Interfaces/Services/IProductService').IProductService

// Mapper
const { Mapper } = require('../../../Core/PlantHere.Aplication/Mapping/ProductProfile');

// RequestResponseModels

// GetProductsCount
const GetProductsCountQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsCount/GetProductsCountQueryResult').GetProductsCountQueryResult

// GetProductsByPage
const GetProductsByPageQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductsByPage/GetProductsByPageQueryResult').GetProductsByPageQueryResult

// GetProductsByCategoryIdAndPage
const GetProductsByCategoryIdAndPageQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductByCategoryIdAndPage/GetProductByCategoryIdAndPageQueryResult').GetProductsByPageAndCategoryIdQueryResult

// GetProductById
const GetProductByIdQueryResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Queries/GetProductById/GetProductByIdQueryResult').GetProductByIdQueryResult

// DeleteProductById
const DeleteProductCommandResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/DeleteProduct/DeleteProductCommandResult').DeleteProductCommandResult

// UpdateProduct
const UpdateProductCommandResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/UpdateProduct/UpdateProductCommandResult').UpdateProductCommandResult

// CreateProduct 
const CreateProductCommandResult = require('../../../Core/PlantHere.Aplication/RequestResponseModels/Product/Commands/CreateProduct/CreateProductCommandResult').CreateProductCommandResult;

const db = require('../../../Infrastructure/PlantHere.Persistance/AppDbContext');
const { Repository } = require("../../../Infrastructure/PlantHere.Persistance/Repositories/Repository");

class ProductService extends Interface(IProductService)
{
    constructor() {
        super()
        this.repository = new Repository(db.Products)
    }

    async getProductsCount() {
        const count = await this.repository.getCount()
        return new GetProductsCountQueryResult(count)
    }

    async getProductsByPage(getProductsByPageQuery) {

        const page = parseInt(getProductsByPageQuery.page)
        const limit = parseInt(getProductsByPageQuery.pageSize)
        const offset = (page - 1) * limit;

        const products = await this.repository.get(['Name', 'Description', 'Price', 'Discount', 'UniqueId'], undefined, limit, offset, db.Images, ['Id', 'Url', 'ProductId'])

        return Mapper(products, GetProductsByPageQueryResult)
    }

    async getProductsByCategoryIdAndPage(getProductsByCategoryIdAndPageQuery, CategoryId) {
        // Params
        const page = parseInt(getProductsByCategoryIdAndPageQuery.page)
        const limit = parseInt(getProductsByCategoryIdAndPageQuery.pageSize)
        const offset = (page - 1) * limit;

        const products = await this.repository.get(['Name', 'UniqueId', 'Description', 'Price', 'CategoryId', 'Discount'], { CategoryId }, limit, offset)

        return new GetProductsByCategoryIdAndPageQueryResult(products)
    }

    async getProductsById(getProductByIdQuery) {
        const products = await this.repository.get(['Name', 'UniqueId', 'SellerId', 'Description', 'Price', 'Discount', 'Id'], { UniqueId: getProductByIdQuery.Id }, undefined, undefined, db.Images, ['Id', 'Url', 'ProductId'])
        return Mapper(products[0], GetProductByIdQueryResult)
    }

    async deleteProduct(deleteProductCommand) {
        return new DeleteProductCommandResult(await this.repository.delete(undefined, { UniqueId: deleteProductCommand.Id }))
    }

    async createProduct(createProductCommand) {
        return new CreateProductCommandResult(await this.repository.create(createProductCommand))
    }

    async updateProduct(updateProductCommand) {
        return new UpdateProductCommandResult(await this.repository.update(updateProductCommand, ["Id"], { Id: updateProductCommand.Id }))
    }
}

module.exports = { ProductService }