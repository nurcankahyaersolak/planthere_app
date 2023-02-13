const IProductService = {
    async getProductsByPage(getProductsByPageQuery) { },
    async getProductsByCategoryIdAndPage(getProductsByCategoryIdAndPageQuery, CategoryId) { },
    async getProductsById(getProductByIdQuery) { },
    async deleteProduct(deleteProductCommand) { },
    async createProduct(createProductCommand) { },
    async updateProduct(updateProductCommand) { },
}

module.exports = { IProductService }