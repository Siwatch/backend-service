using service.Models.DTO;

namespace service.Repository;
public interface IProductRepo {
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int id);
    Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO);
    Task<bool> DeleteProduct(int id);
     
}