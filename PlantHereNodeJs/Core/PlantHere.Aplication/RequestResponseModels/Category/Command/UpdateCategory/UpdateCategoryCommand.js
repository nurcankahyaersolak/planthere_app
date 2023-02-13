class UpdateCategoryCommand{
    constructor(id,nameEn,nameTr) {
        this.Id  = id,
        this.NameEn = nameEn,
        this.NameTr = nameTr
    }
}

module.exports = {UpdateCategoryCommand}
