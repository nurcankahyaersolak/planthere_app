const {Sequelize,DataTypes} = require('sequelize');
module.exports = function(sequelize) {
  return sequelize.define('BasketItems', {
    Id: {
      autoIncrement: true,
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
    BasketId: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'Baskets',
        key: 'Id'
      }
    }
  }, {
    sequelize,
    tableName: 'BasketItems',
    schema: 'basketing',
    timestamps: false,
    indexes: [
      {
        name: "IX_BasketItems_BasketId",
        fields: [
          { name: "BasketId" },
        ]
      },
      {
        name: "PK_BasketItems",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
