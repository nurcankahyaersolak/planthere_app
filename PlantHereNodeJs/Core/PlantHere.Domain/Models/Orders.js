const {Sequelize,DataTypes}= require('sequelize');

module.exports = function(sequelize) {
  return sequelize.define('Orders', {
    Id: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    CreatedDate: {
      type: DataTypes.DATE,
      allowNull: false
    },
    Address_Province: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    Address_District: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    Address_Street: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    Address_ZipCode: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    Address_Line: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    BuyerId: {
      type: DataTypes.TEXT,
      allowNull: false
    }
  }, {
    sequelize,
    tableName: 'Orders',
    schema: 'ordering',
    timestamps: false,
    indexes: [
      {
        name: "PK_Orders",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
