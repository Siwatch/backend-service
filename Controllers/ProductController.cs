using Microsoft.AspNetCore.Mvc;
using service.Models.DTO;
using service.Repository;

namespace service.Controller;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    protected ResponseDTO _reponseDTO;
    private IProductRepo _productRepo;
    public ProductController(IProductRepo productRepo)
    {
        _productRepo = productRepo;
        this._reponseDTO = new ResponseDTO();
    }

    [HttpPost]
    public async Task<object> Post([FromBody] ProductDTO productDTO)
    {
        try
        {
            ProductDTO product = await _productRepo.CreateUpdateProduct(productDTO);
            _reponseDTO.Result = product;
        }
        catch (Exception ex)
        {
            _reponseDTO.IsSuccess = false;
            _reponseDTO.ErrorMessage = new List<string>() { ex.ToString() };
        }
        return _reponseDTO;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] ProductDTO productDTO)
    {
        try
        {
            ProductDTO product = await _productRepo.CreateUpdateProduct(productDTO);
            _reponseDTO.Result = product;
        }
        catch (Exception ex)
        {
            _reponseDTO.IsSuccess = false;
            _reponseDTO.ErrorMessage = new List<string>() { ex.ToString() };
        }
        return _reponseDTO;
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _productRepo.DeleteProduct(id);
            _reponseDTO.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _reponseDTO.IsSuccess = false;
            _reponseDTO.ErrorMessage = new List<string>() { ex.ToString() };
        }
        return _reponseDTO;
    }
    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductDTO> productDTO = await _productRepo.GetProducts();
            _reponseDTO.Result = productDTO;
        }
        catch (Exception ex)
        {
            _reponseDTO.IsSuccess = false;
            _reponseDTO.ErrorMessage = new List<string>() { ex.ToString() };
        }
        return _reponseDTO;
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            ProductDTO productDTO = await _productRepo.GetProductById(id);
            _reponseDTO.Result = productDTO;
        }
        catch (Exception ex)
        {
            _reponseDTO.IsSuccess = false;
            _reponseDTO.ErrorMessage = new List<string>() { ex.ToString() };
        }
        return _reponseDTO;
    }

}