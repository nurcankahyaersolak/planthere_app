var DataTypes = require("sequelize").DataTypes;
var _BasketItems = require("./BasketItems");
var _Baskets = require("./Baskets");
var _Category = require("./Category");
var _OrderItems = require("./OrderItems");
var _Orders = require("./Orders");
var _Products = require("./Products");
var ___EFMigrationsHistory = require("./__EFMigrationsHistory");

function initModels(sequelize) {
  var BasketItems = _BasketItems(sequelize, DataTypes);
  var Baskets = _Baskets(sequelize, DataTypes);
  var Category = _Category(sequelize, DataTypes);
  var OrderItems = _OrderItems(sequelize, DataTypes);
  var Orders = _Orders(sequelize, DataTypes);
  var Products = _Products(sequelize, DataTypes);
  var __EFMigrationsHistory = ___EFMigrationsHistory(sequelize, DataTypes);

  BasketItems.belongsTo(Baskets, { as: "Basket", foreignKey: "BasketId"});
  Baskets.hasMany(BasketItems, { as: "BasketItems", foreignKey: "BasketId"});
  Products.belongsTo(Category, { as: "Category", foreignKey: "CategoryId"});
  Category.hasMany(Products, { as: "Products", foreignKey: "CategoryId"});
  OrderItems.belongsTo(Orders, { as: "Order", foreignKey: "OrderId"});
  Orders.hasMany(OrderItems, { as: "OrderItems", foreignKey: "OrderId"});

  return {
    BasketItems,
    Baskets,
    Category,
    OrderItems,
    Orders,
    Products,
    __EFMigrationsHistory,
  };
}
module.exports = initModels;
module.exports.initModels = initModels;
module.exports.default = initModels;
