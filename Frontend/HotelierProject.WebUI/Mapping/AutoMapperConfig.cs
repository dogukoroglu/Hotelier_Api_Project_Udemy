using AutoMapper;
using HotelierProject.EntityLayer.Concrete;
using HotelierProject.WebUI.Dtos.LoginDto;
using HotelierProject.WebUI.Dtos.RegisterDto;
using HotelierProject.WebUI.Dtos.ServiceDto;

namespace HotelierProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
           CreateMap<ResultServiceDto,Service>().ReverseMap();
           CreateMap<UpdateServiceDto,Service>().ReverseMap();
           CreateMap<CreateServiceDto,Service>().ReverseMap();

           CreateMap<CreateNewUserDto,AppUser>().ReverseMap();
           CreateMap<LoginUserDto,AppUser>().ReverseMap();
        }
    }
}
