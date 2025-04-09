using AutoMapper;
using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Repositories;
using CarMember_server.Servicies.Interfaces;

namespace CarMember_server.Servicies
{
    public class UserService : IUserService
    {

        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository,
                              IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserRegisterResponseDTO> Create(UserRegisterRequestDTO UserRegisterRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDeleteProfilRequestDTO> Delete(UserDeleteProfilRequestDTO UserDeleteRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserProfilResponseDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserProfilResponseDTO>>(
                await _userRepository.GetAll() 
                );
        }

        public async Task<UserProfilResponseDTO?> GetByEmail(UserProfilRequestDTO UserProfilRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfilResponseDTO?> GetById(UserProfilRequestDTO UserProfilRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserUpdateResponseDTO> Update(UserUpdateRequestDTO UserProfilRequest)
        {
            throw new NotImplementedException();
        }


    }
}
