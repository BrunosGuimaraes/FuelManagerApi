using AutoMapper;
using FuelManagerApi.DTOs.Requests;
using FuelManagerApi.DTOs.Responses;
using FuelManagerApi.Models;

namespace FuelManagerApi.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Veiculo, VeiculoRequestDto>().ReverseMap();
            CreateMap<Veiculo, VeiculoResponseDto>().ReverseMap();

            CreateMap<Consumo, ConsumoRequestDto>().ReverseMap();
            CreateMap<Consumo, ConsumoResponseDto>().ReverseMap();
        }
    }
}
