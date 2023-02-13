const {Sequelize,DataTypes}= require('sequelize');

module.exports = function(sequelize) {
  return sequelize.define('OrderItems', {
    Id: {
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    ProductId: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    ProductName: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    Price: {
      type: DataTypes.DECIMAL(18,2),
      allowNull: false
    },
    DiscountedPrice: {
      type: DataTypes.DECIMAL(18,2),
      allowNull: false
    },
    Count: {
      type: DataTypes.INTEGER,
      allowNull: false
    },
    OrderId: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'Orders',
        key: 'Id'
      }
    }
  }, {
    sequelize,
    tableName: 'OrderItems',
    schema: 'ordering',
    timestamps: false,
    indexes: [
      {
        name: "IX_OrderItems_OrderId",
        fields: [
          { name: "OrderId" },
        ]
      },
      {
        name: "PK_OrderItems",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
