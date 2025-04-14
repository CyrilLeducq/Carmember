using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using AutoMapper;
using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Helpers;
using CarMember_server.Models;
using CarMember_server.Repositories;
using CarMember_server.Servicies.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CarMember_server.Servicies
{
    public class UserService : IUserService
    {

        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly Encryptor _encryptor;

        public UserService(UserRepository userRepository,
                              IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encryptor = new Encryptor();
        }

        public async Task<User?> GetUserById(string email)
        {
            return await _userRepository.Get(u => u.Email.Contains(email));
        }

        public async Task<IEnumerable<UserPersonnalProfilResponseDTO>> GetAll()
        {
            List<UserPersonnalProfilResponseDTO> responseDTO = [];
            var users = await _userRepository.GetAll();

            foreach (var user in users)
            {
                responseDTO.Add(new UserPersonnalProfilResponseDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Gender = user.Gender,
                    ProfilePicture = user.ProfilePicture,
                    CreatedAt = user.CreationDate ?? new DateTime(2025, 01, 01),

                    

                    ReceivedReviews = null,
                    GivenReviews = null,
                    PastRides = null,
                    UpcomingRides = null
                });
            }

            return responseDTO;
        }


        public async Task<UserPersonnalProfilResponseDTO?> GetPersonnalByEmail(string email)
        {

            var user = await _userRepository.Get(u => u.Email.Contains(email));

            if (user == null) return null;

            return new UserPersonnalProfilResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                ProfilePicture = user.ProfilePicture,
                CreatedAt = user.CreationDate ?? new DateTime(2025, 01, 01),

                ReceivedReviews = null,
                GivenReviews = null,
                PastRides = null,
                UpcomingRides = null
            };
        }

        public async Task<UserPersonnalProfilResponseDTO?> GetPersonnalById(Guid id)
        {
            var user = await _userRepository.Get(u => u.Id == (id));

            if (user == null) return null;

            return new UserPersonnalProfilResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                ProfilePicture = user.ProfilePicture,
                CreatedAt = user.CreationDate ?? new DateTime(2025, 01, 01),

                ReceivedReviews = null,
                GivenReviews = null,
                PastRides = null,
                UpcomingRides = null
            };
        }

        public async Task<OtherUserProfilResponseDTO?> GetOtherById(OtherUserProfilRequest otherUserProfilRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRegisterResponseDTO> Create(UserRegisterRequestDTO userRegisterRequest)
        {

            if (await GetPersonnalByEmail(userRegisterRequest.Email!) is not null)
                throw new InvalidOperationException("Email already exist !");

            var user = await _userRepository.Add(new User
            {
                Id = new Guid(),
                FirstName = userRegisterRequest.FirstName,
                LastName = userRegisterRequest.LastName,
                Email = userRegisterRequest.Email,
                Password = _encryptor.EncryptPassword(userRegisterRequest.Password!),
                PhoneNumber = userRegisterRequest.PhoneNumber,
                ProfilePicture = userRegisterRequest.ProfilePicture,
                Gender = userRegisterRequest.Gender,
                CreationDate = DateTime.Now,
                Role = Constants.RoleUsers
            });

            return new UserRegisterResponseDTO
            {
                IsSuccessful = true,
                User = user
            };

        }
        public async Task<UserUpdateResponseDTO> Update(UserUpdateRequestDTO UserProfilRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDeleteProfilRequestDTO> Delete(UserDeleteProfilRequestDTO UserDeleteRequest)
        {
            throw new NotImplementedException();
        }


    }
}
