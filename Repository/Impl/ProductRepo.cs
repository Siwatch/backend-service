using AutoMapper;
using Microsoft.EntityFrameworkCore;
using service.Data;
using service.Models;
using service.Models.DTO;

namespace service.Repository.Impl;
public class ProductRepo : IProductRepo
{
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;
    public ProductRepo(ApplicationDbContext db,IMapper mapper)
    {
        _mapper = mapper;
        _db = db;
    }
    
    public async Task<ProductDTO> CreateUpdateProduct(ProductDTO productDTO)
    {
        Product product = _mapper.Map<ProductDTO,Product>(productDTO);
        if(product.ProductId > 0) {
            _db.Product.Update(product);
        }else {
            _db.Product.Add(product);
        }
        await _db.SaveChangesAsync();
        return _mapper.Map<Product,ProductDTO>(product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        try{
            Product product = await _db.Product.FirstOrDefaultAsync(product => product.ProductId == id);
            if( product == null ) {
                return false;
            }
            _db.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }catch (Exception ex){
            return false;
        }
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        Product productById = await _db.Product.Where(product => product.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<ProductDTO>(productById);
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        List<Product> productList = await _db.Product.ToListAsync();
        return _mapper.Map<List<ProductDTO>>(productList);
    }
}