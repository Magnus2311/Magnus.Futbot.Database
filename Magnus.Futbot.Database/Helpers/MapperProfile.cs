using AutoMapper;
using Magnus.Futbot.Common.Models.DTOs;
using Magnus.Futbot.Common.Models.Selenium.Profiles;
using Magnus.Futbot.Database.Models;

namespace Magnus.Futbot.Database.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PlayerDTO, PlayerDocument>();
            CreateMap<AddProfileDTO, ProfileDocument>();
        }
    }
}
