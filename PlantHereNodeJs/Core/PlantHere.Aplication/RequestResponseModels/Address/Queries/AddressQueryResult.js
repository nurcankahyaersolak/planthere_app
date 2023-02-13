class AddressQueryResult
{
    constructor(province,district,street,zipCode,line) {
        this.province = province,
        this.district = district,
        this.street = street,
        this.zipCode = zipCode,
        this.line = line
    }
}

module.exports = {AddressQueryResult}