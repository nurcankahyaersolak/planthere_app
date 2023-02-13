const createError = require('http-errors')
const jwt = require('jsonwebtoken')
const config = require('../../../Presentation/PlantHere.WebAPI/app.config')

const Authorization = async (req, res, next) => {

    try {
        const authorization = req.header('Authorization').replace('Bearer ', '')
        const token = authorization
        const jsonToken = await jwt.verify(token, config.tokenOption.securityKey, { algorithms: ['HS256'] })
        const { 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': roles } = jsonToken

        if (!req.allowedRoles) {
            throw createError(403)
        }
        
        let result = false

        req.allowedRoles.forEach(element => {
            if (roles.includes(element)) {
                result = true
            }
        });
        
        if (!result) {
            throw createError(403)
        }

        next()

    } catch (error) {
        next(error)
    }

}

module.exports = Authorization;