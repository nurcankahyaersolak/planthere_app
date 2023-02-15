
// Interface
const Interface = require("es6-interface");
const { ICategoryService } = require('../../../Core/PlantHere.Aplication/Interfaces/Services/ICategoryService')
const { Repository } = require('../../../Infrastructure/PlantHere.Persistance/Repositories/Repository')

// RequestResponseModels
// GetCategories
const { GetCategoriesQuery } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategories/GetCategoriesQuery")
const { GetCategoriesQueryResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategories/GetCategoriesQueryResult")

// GetCategoryById 
const { GetCategoryByIdQuery } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategoryById/GetCategoryByIdQuery")
const { GetCategoryByIdQueryResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Queries/GetCategoryById/GetCategoryByIdQueryResult")

const { CreateCategoryCommandResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/CreateCategory/CreateCategoryCommandResult")
const { UpdateCategoryCommandResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/UpdateCategory/UpdateCategoryCommandResult")
const { DeleteCategoryCommandResult } = require("../../../Core/PlantHere.Aplication/RequestResponseModels/Category/Command/DeleteCategory/DeleteCategoryCommandResult")

// Db
const db = require('../../../Infrastructure/PlantHere.Persistance/AppDbContext');

class CategoryService extends Interface(ICategoryService)
{
    constructor() {
        super()
        this.repository = new Repository(db.Categories)
    }

    async getCategories() {
        const categories = await this.repository.get(["NameTr", "NameEn", "Id"])
        return new GetCategoriesQueryResult(categories)
    }

    async getCategoryById(req) {
        const categories = await this.repository.get(["NameTr", "NameEn", "Id"], { Id: req.Id })
        return new GetCategoryByIdQueryResult(categories[0].NameEn,categories[0].NameTr)
    }

    async createCategory(req) {
        return new CreateCategoryCommandResult(await this.repository.create(req))
    }

    async updateCategory(req) {
        return new UpdateCategoryCommandResult(await this.repository.update(req, ["Id"], { Id: req.Id }))
    }

    async deleteCategory(req) {
        return new DeleteCategoryCommandResult(await this.repository.delete(["Id"], { Id: req.Id }))
    }
}

module.exports = { CategoryService }