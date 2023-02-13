// Http Error
const CreateError = require('http-errors')

class Repository {

    constructor(model) {
        this.model = model
    }

    async get(attributes, where, limit, offset, includeModel, includeAttributes,notFoundControl=true) {

        let include = undefined

        if (includeModel) {
            include = { model: includeModel, attributes: includeAttributes }
        }

        const result = await this.model.findAll({
            attributes,
            where,
            limit,
            offset,
            include
        })
        
        if (!result[0] && notFoundControl) {
            throw new CreateError.NotFound()
        }

        return result
    }

    async create(body) {
        return await this.model.create(body)
    }

    async delete(attributes, where) {
        const result = await this.get(attributes, where)
        result[0].destroy()
    }

    async update(body, attributes, where) {
        const result = await this.get(attributes, where)
        if (body.Id) {
            delete body.Id
        }
        result[0].update(body)
    }

    async getCount(){
        return await this.model.count()        
    }
}


module.exports = { Repository }