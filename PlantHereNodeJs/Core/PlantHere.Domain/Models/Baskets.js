const {Sequelize,DataTypes}= require('sequelize');

module.exports = function(sequelize) {
  return sequelize.define('Baskets', {
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
    UserId: {
      type: DataTypes.TEXT,
      allowNull: false
    }
  }, {
    sequelize,
    tableName: 'Baskets',
    schema: 'basketing',
    timestamps: false,
    indexes: [
      {
        name: "PK_Baskets",
        unique: true,
        fields: [
          { name: "Id" },
        ]
      },
    ]
  });
};
