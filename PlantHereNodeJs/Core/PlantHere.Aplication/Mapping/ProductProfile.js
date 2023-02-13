const {GetImagesQueryResult} = require('../../PlantHere.Aplication/RequestResponseModels/Image/Queries/GetImagesQueryResult')
const Mapper = (value, classes) => {
    if (Array.isArray(value)) {
        images = []
        returnArray = []
        value.forEach(element => {
            element.Images.forEach(image => {
                image = new GetImagesQueryResult(image.Id, image.Url, image.ProductId)
                images.push(image)
            }
            )
            returnArray.push(new classes(element.Name, element.Description, element.Discount, element.Price, element.UniqueId, images))
            images =[]
        });

        return returnArray;
    }

    else {
        images = []
        value.Images.forEach(image => {
            image = new GetImagesQueryResult(image.Id, image.Url, image.ProductId)
            images.push(image)
        })
        return new classes(value.Name, value.Description, value.Discount, value.Price, value.UniqueId, images)
    }

}


module.exports = { Mapper }


