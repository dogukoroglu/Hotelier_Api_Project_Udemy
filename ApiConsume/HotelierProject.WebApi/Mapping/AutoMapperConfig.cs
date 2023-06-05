using AutoMapper;
using HotelierProject.DtoLayer.Dtos.RoomDto;
using HotelierProject.EntityLayer.Concrete;

namespace HotelierProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddRoomDto, Room>().ReverseMap();
            
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
