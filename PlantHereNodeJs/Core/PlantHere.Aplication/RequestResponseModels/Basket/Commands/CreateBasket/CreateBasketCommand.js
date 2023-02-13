const Guid = require("../../../../../PlantHere.Aplication/Services/GuidService")

class CreateBasketCommand{
    constructor(userId) {
        this.UserId = userId,
        this.UniqueId  = Guid.createGuid()
        this.CreatedDate =  Guid.dateNow(); 
        this.UpdatedDate =  Guid.dateNow(); 
    }
}

module.exports =  {CreateBasketCommand}