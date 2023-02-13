
// Express 
const express = require('express')

//Cors
const cors = require('cors')

// Middlewares
const { CustomExceptionHandle } = require('./Middlewares/CustomExceptionHandler')
const Authentication = require('../../Core/PlantHere.Aplication/Middlewares/AuthenticationMiddleware')
const Authorization = require('../../Core/PlantHere.Aplication/Middlewares/AuthorizationMiddleware')

// Chalk
const chalk = require('chalk')

// Router
const productRouter = require('./Routers/ProductRouter')
const categoryRouter = require('./Routers/CategoryRouter')
const basketRouter = require('./Routers/BasketRouter')
const basketItemRouter = require('./Routers/BasketItemRouter')
const orderRouter = require('./Routers/OrderRouter')

// Connect DB
// require('../../Infrastructure/PlantHere.Persistance/AppDbContext')

// App
const app = express();

app.use(express.json())
app.use(cors())


// Router
app.use('/product', productRouter)
app.use('/category', categoryRouter)
app.use('/basket', basketRouter)
app.use('/basketItem', basketItemRouter)
app.use('/order', orderRouter)

//Swagger Integration
var swaggerUi = require('swagger-ui-express');
swaggerDocument = require('./swagger/swagger.json');
app.use('/swagger', swaggerUi.serve, swaggerUi.setup(swaggerDocument));

// Middlewares
app.use(CustomExceptionHandle)
app.use(Authentication)
app.use(Authorization)

// Listen
const config = require('./app.config')

app.listen(config.apiUrl.port, () => {
    console.log(chalk.rgb(0, 255, 0)(`------- Service Active On Port ${config.apiUrl.port} -------`))
})
