const {Sequelize,DataTypes}= require('sequelize');
module.exports = function(sequelize) {
  return sequelize.define('Category', {
    Id: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    NameTr: {
      type: DataTypes.STRING(50),
      allowNull: false
    },
    NameEn: {
      type: DataTypes.STRING(50),
      allowNull: false
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
    tableName: 'Category',
    schema: 'dbo',
    timestamps: false,
    indexes: [
      {
        name: "PK_Category",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
