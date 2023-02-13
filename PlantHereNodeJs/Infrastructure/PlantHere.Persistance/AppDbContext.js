const { Sequelize } = require('sequelize');
const chalk = require('chalk')
const config = require('../../Presentation/PlantHere.WebAPI/app.config')


const sequelize = new Sequelize(config.connection.database, config.connection.user, config.connection.password, {
    host: config.connection.server,
    dialect: config.connection.client
});

try {
    sequelize.authenticate();
    console.log(chalk.rgb(0, 255, 150)('( Connection has been established successfully...)'));
} catch (error) {
    console.log(chalk.rgb(255, 0, 0)('Unable to connect to the database:', error));
}

const Products = require('../../Core/PlantHere.Domain/Models/Products')(sequelize)
const Category = require('../../Core/PlantHere.Domain/Models/Category')(sequelize)
const Baskets = require('../../Core/PlantHere.Domain/Models/Baskets')(sequelize)
const BasketItems = require('../../Core/PlantHere.Domain/Models/BasketItems')(sequelize)
const Orders = require('../../Core/PlantHere.Domain/Models/Orders')(sequelize)
const OrderItems = require('../../Core/PlantHere.Domain/Models/OrderItems')(sequelize)
const Image = require('../../Core/PlantHere.Domain/Models/Image')(sequelize)

Products.belongsTo(Category, { foreignKey: 'CategoryId' })
Baskets.hasMany(BasketItems)
Orders.hasMany(OrderItems, { foreignKey: 'OrderId' })
Products.hasMany(Image, { foreignKey: 'ProductId' })

module.exports = {
    Products,
    Categories: Category,
    Baskets,
    BasketItems,
    Orders,
    OrderItems,
    Images: Image
} 