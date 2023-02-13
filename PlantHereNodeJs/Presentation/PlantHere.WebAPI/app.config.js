const config = {
    app:{
      name:"PlantHere"  
    },
    connection: {
        client:"mssql",
        server:"planthere_db",
        user:"sa",
        password:"password123.",
        database:"planthere"
    },
    apiUrl:{
      baseUrl:"http://localhost:4000/",
      port:4000
    }
    ,
    tokenOption:{
      securityKey :"marvindennisgames2022*"
    }
}


module.exports = (config)