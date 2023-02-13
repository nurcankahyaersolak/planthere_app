const {Sequelize,DataTypes}= require('sequelize');

module.exports = function(sequelize) {
  return sequelize.define('Products', {
    Id: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    Name: {
      type: DataTypes.TEXT,
      allowNull: true
    },
    Description: {
      type: DataTypes.TEXT,
      allowNull: true
    },
    Stock: {
      type: DataTypes.INTEGER,
      allowNull: false
    },
    Price: {
      type: DataTypes.DECIMAL(18,2),
      allowNull: false
    },
    SellerId: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    CategoryId: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'Category',
        key: 'Id'
      }
    },
    Discount: {
      type: DataTypes.INTEGER,
      allowNull: false
    },
    Care: {
      type: DataTypes.TEXT,
      allowNull: true
    },
    UniqueId: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    CreatedDate: {
      type: DataTypes.DATE,
      allowNull: true
    },
    UpdatedDate: {
      type: DataTypes.DATE,
      allowNull: true
    }
  }, {
    sequelize,
    tableName: 'Products',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "IX_Products_CategoryId",
        fields: [
          { name: "CategoryId" },
        ]
      },
      {
        name: "PK_Products",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
