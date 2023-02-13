const createError = require('http-errors')
const jwt = require('jsonwebtoken')
const config = require('../../../Presentation/PlantHere.WebAPI/app.config')

const Authorization = async (req, res, next) => {
    try {
        if (!req.header('Authorization')) {
            throw createError(401)
        }
        const authorization = req.header('Authorization').replace('Bearer ', '')

        if (!authorization) {
            throw createError(401)
        }
        const token = authorization
        const jsonToken = await jwt.verify(token, config.tokenOption.securityKey,{ algorithms: ['HS256'] })
        
        if (!jsonToken) {
            throw createError(401)
        }
        
        const { 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier': userId } = jsonToken

        req.userId = userId
        
        next()
    } catch (error) {
        next(error)
    }
}

module.exports = Authorization;