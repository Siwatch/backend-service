using AutoMapper;
using service.Models;
using service.Models.DTO;

namespace service.Mapper;
public class MapperConfig {
    public static MapperConfiguration RegisterMap(){

        var mappingConfig = new MapperConfiguration(config => {
            config.CreateMap<ProductDTO,Product>();
            config.CreateMap<Product,ProductDTO>();
        });
        return mappingConfig;
    }
}