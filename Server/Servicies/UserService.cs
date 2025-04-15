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

namespace CarMember_server.Servicies;

public class UserService : IUserService
{

    private readonly UserRepository _userRepository;
    private readonly RideRepository _rideRepository;
    private readonly RideUserRepository _rideUserRepository;
    private readonly IMapper _mapper;
    private readonly Encryptor _encryptor;

    public UserService(UserRepository userRepository,
                        RideRepository rideRepository,
                        RideUserRepository rideUserRepository,
                          IMapper mapper)
    {
        _userRepository = userRepository;
        _rideRepository = rideRepository;
        _rideUserRepository = rideUserRepository;
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
            List<Ride> rides = await AllRides(user);

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

                ReceivedReviews = user.ReviewedReviews,
                GivenReviews = user.AuthorReviews,
                PastRides = rides.Where(r => r.DepartureDate < DateTime.Now).ToList(),
                UpcomingRides = rides.Where(r => r.DepartureDate >= DateTime.Now).ToList()
            });
        }

        return responseDTO;
    }


    public async Task<UserPersonnalProfilResponseDTO?> GetPersonnalByEmail(string email)
    {

        var user = await _userRepository.Get(u => u.Email.Contains(email));

        if (user == null) return null;

        List<Ride> rides = await AllRides(user);

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

            ReceivedReviews = user.ReviewedReviews,
            GivenReviews = user.AuthorReviews,
            PastRides = rides.Where(r => r.DepartureDate < DateTime.Now).ToList(),
            UpcomingRides = rides.Where(r => r.DepartureDate >= DateTime.Now).ToList()
        };
    }

    public async Task<UserPersonnalProfilResponseDTO?> GetPersonnalById(Guid id)
    {
        var user = await _userRepository.Get(u => u.Id == (id));

        if (user == null) return null;

        Console.WriteLine($"-------------\n Rides: {user.ConductorRides}");

        List<Ride> rides = await AllRides(user);

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
            ReceivedReviews = user.ReviewedReviews,
            GivenReviews = user.AuthorReviews,
            PastRides = rides.Where(r => r.DepartureDate < DateTime.Now).ToList(),
            UpcomingRides = rides.Where(r => r.DepartureDate >= DateTime.Now).ToList()
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
        var userFromDb = await _userRepository.Get(u => u.Id == UserProfilRequest.Id);

        if (userFromDb == null) return null;


        if (userFromDb.FirstName != UserProfilRequest.FirstName)
            userFromDb.FirstName = UserProfilRequest.FirstName;
        if (userFromDb.LastName != UserProfilRequest.LastName)
            userFromDb.LastName = UserProfilRequest.LastName;
        if (userFromDb.Email != UserProfilRequest.Email)
            userFromDb.Email = UserProfilRequest.Email;
        if (userFromDb.PhoneNumber != UserProfilRequest.PhoneNumber)
            userFromDb.PhoneNumber = UserProfilRequest.PhoneNumber;

        if ( ! (UserProfilRequest.Password == null))
        {
            userFromDb.Password = _encryptor.EncryptPassword(UserProfilRequest.Password!);
        }

        if (userFromDb.ProfilePicture != UserProfilRequest.ProfilePicture)
            userFromDb.ProfilePicture = UserProfilRequest.ProfilePicture;
        if (userFromDb.Gender != UserProfilRequest.Gender)
            userFromDb.Gender = UserProfilRequest.Gender;

        return new UserUpdateResponseDTO{
            IsSuccessful= true,
            User = userFromDb
            };
    }

    public async Task<UserDeleteProfilResponseDTO> Delete(UserDeleteProfilRequestDTO UserDeleteRequest)
    {
        try
        {
            if (!await _userRepository.Delete(UserDeleteRequest.UserId))
                throw new KeyNotFoundException($"Utilisateur avec l'id {UserDeleteRequest.UserId} non trouvé.");
            return new UserDeleteProfilResponseDTO
            {
                IsSuccessful = true,
                ErrorMessage = "",
                UserId = UserDeleteRequest.UserId
            };
        }

        catch (Exception e)
        {
            // Ajout du Logging de l'erreur rencontrée
            Console.WriteLine($"Erreur de modification pour le user avec l'id {UserDeleteRequest.UserId}: {e.Message}");
            Console.WriteLine(e.StackTrace);
            throw;
        }
    }

    private async Task<List<Ride>>? AllRides(User user)
    {
        List<Ride> rides = [];
        foreach (var rideUsers in user.RideUsers)
        {
            Ride rideFinded = await _rideRepository.GetById(rideUsers.Id);

            rides.Add(rideFinded);
        }

        foreach (var ride in user.ConductorRides)
        {
            rides.Add(ride);
        }

        return rides;
    }
}
