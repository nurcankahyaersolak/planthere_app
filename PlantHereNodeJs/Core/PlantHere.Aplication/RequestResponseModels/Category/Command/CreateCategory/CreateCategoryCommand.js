class CreateCategoryCommand {
    constructor(nameEn, nameTr,uniqueId) {
        this.NameEn = nameEn,
        this.NameTr = nameTr
        this.UniqueId = uniqueId
    }
}

module.exports = { CreateCategoryCommand }
