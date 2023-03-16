using service.Models.DTO;

namespace service.Repository.Impl;
public class ProductRepo : IProductRepo
{
    public Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDTO>> GetProducts()
    {
        throw new NotImplementedException();
    }
}