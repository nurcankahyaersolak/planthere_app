const {Sequelize,DataTypes}= require('sequelize');

module.exports = function(sequelize) {
  return sequelize.define('Image', {
    Id: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    Url: {
      type: DataTypes.TEXT,
      allowNull: false
    },
    ProductId: {
      type: DataTypes.INTEGER,
      allowNull: false,
      references: {
        model: 'Products',
        key: 'Id'
      }
    }
  }, {
    sequelize,
    tableName: 'Image',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "IX_Image_ProductId",
        fields: [
          { name: "ProductId" },
        ]
      },
      {
        name: "PK_Image",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
