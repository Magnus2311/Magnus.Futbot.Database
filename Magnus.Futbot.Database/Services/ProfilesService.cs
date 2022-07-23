using AutoMapper;
using Magnus.Futbot.Common.Models.Selenium.Profiles;
using Magnus.Futbot.Database.Models;
using Magnus.Futbot.Database.Repositories;

namespace Magnus.Futbot.Database.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _profilesRepository;
        private readonly IMapper _mapper;

        public ProfilesService(ProfilesRepository profilesRepository,
            IMapper mapper)
        {
            _profilesRepository = profilesRepository;
            _mapper = mapper;
        }

        public Task Add(AddProfileDTO profileDTO)
            => _profilesRepository.Add(_mapper.Map<ProfileDocument>(profileDTO));
    }
}
