using System.ComponentModel.DataAnnotations;
using Azure;
using CarMember_server.DTOs.RidesDTO;
using CarMember_server.Models;
using CarMember_server.Repositories;
using CarMember_server.Servicies.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CarMember_server.Servicies
{
    public class RideService : IRideService
    {
        private readonly RideRepository _rideRepository;
        private readonly UserRepository _userRepository;
        private readonly ILogger<RideService> _logger;

        public RideService(
            RideRepository rideRepository,
            UserRepository userRepository,
            ILogger<RideService> logger)
        {
            _rideRepository = rideRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        //Implémentations des methodes
        // CREATE
        public async Task<RideCreateResponseDTO> CreateRide(RideCreateRequestDTO request)
        {
           
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(request); 
           
            
            var driver = await _userRepository.GetById(request.DriverUserId);
            if (driver == null)
            {
                _logger.LogWarning($"User with ID {request.DriverUserId} not found.");
                throw new InvalidOperationException("User not found.");
            }

            
            var ride = new Ride
            {
                Id = Guid.NewGuid(),
                DriverUserId = request.DriverUserId, 
                DepartureDate = request.DepartureDate,
                DepartureLocationCity = request.DepartureLocationCity,
                DepartureLocationAdress = request.DepartureLocationAddress,
                ArrivalLocationCity = request.ArrivalLocationCity,
                ArrivalLocationAdress = request.ArrivalLocationAddress,
                Duration = (int)request.Duration.TotalMinutes, 
                CostHeight = request.CheeseCostInGrams, 
                CostCheeseType = request.CheeseType,
                MusicalPreference = request.MusicalPreference,
                AnimalPreference = request.AnimalPreference,
                SmokingPreference = request.SmokingPreference,
                TalkingPreference = request.TalkingPreference
            };

            
            var createdRide = await _rideRepository.Add(ride);

            
            _logger.LogInformation($"Ride with ID {createdRide.Id} created successfully by user {request.DriverUserId}.");

            
            var response = new RideCreateResponseDTO
            {
                IsSuccessful = true,
                RideId = createdRide.Id,
                DriverUserId = createdRide.DriverUserId,
                DepartureDate = (DateTime)createdRide.DepartureDate,
                DepartureLocationCity = createdRide.DepartureLocationCity,
                DepartureLocationAdress = createdRide.DepartureLocationAdress,
                ArrivalLocationCity = createdRide.ArrivalLocationCity,
                ArrivalLocationAdress = createdRide.ArrivalLocationAdress,
                Duration = createdRide.Duration,
                CostHeight = createdRide.CostHeight,
                CostCheeseType = createdRide.CostCheeseType.ToString(),
                MusicalPreference = createdRide.MusicalPreference.ToString(),
                AnimalPreference = createdRide.AnimalPreference.ToString(),
                SmokingPreference = createdRide.SmokingPreference.ToString(),
                TalkingPreference = createdRide.TalkingPreference.ToString()
            };

            return response;
        }
        // UPDATERIDE
        public async Task<RideUpdateResponseDTO> UpdateRide(Guid rideId, RideUpdateRequestDTO request)
        {
            
            var existingRide = await _rideRepository.GetById(rideId);
            if (existingRide == null)
            {
                _logger.LogWarning($"Ride with ID {rideId} not found.");
                return new RideUpdateResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "Ride not found."
                };
            }

            
            existingRide.DepartureDate = request.DepartureDate;
            existingRide.DepartureLocationCity = request.DepartureLocationCity;
            existingRide.DepartureLocationAdress = request.DepartureLocationAddress;
            existingRide.ArrivalLocationCity = request.ArrivalLocationCity;
            existingRide.ArrivalLocationAdress = request.ArrivalLocationAddress;
            existingRide.Duration = (int)request.Duration.TotalMinutes;  
            existingRide.CostHeight = request.CheeseCostInGrams;
            existingRide.CostCheeseType = request.CheeseType;
            existingRide.MusicalPreference = request.MusicalPreference;
            existingRide.AnimalPreference = request.AnimalPreference;
            existingRide.SmokingPreference = request.SmokingPreference;
            existingRide.TalkingPreference = request.TalkingPreference;

            
            var updatedRide = await _rideRepository.Update(existingRide);

            
            _logger.LogInformation($"Ride with ID {updatedRide.Id} updated successfully.");

            
            var response = new RideUpdateResponseDTO
            {
                IsSuccessful = true,
                UpdatedRide = updatedRide 
            };

            return response;
        }
        public async Task<RideViewResponseDTO> ViewRideDetails(RideViewRequestDTO request)
        {
            
            var ride = await _rideRepository.GetById(request.RideId);  
            if (ride == null)
            {
                _logger.LogWarning($"Ride with ID {request.RideId} not found.");
                return new RideViewResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "Ride not found."
                };
            }

            
            var passengers = await _rideRepository.GetPassengersByRideId(request.RideId);

            
            var response = new RideViewResponseDTO
            {
                IsSuccessful = true,
                DepartureDate = (DateTime)ride.DepartureDate,
                DepartureLocationCity = ride.DepartureLocationCity,
                DepartureLocationAddress = ride.DepartureLocationAdress,
                ArrivalLocationCity = ride.ArrivalLocationCity,
                ArrivalLocationAddress = ride.ArrivalLocationAdress,
                DurationInMinutes = ride.Duration,
                CheeseCostInGrams = ride.CostHeight,
                CheeseType = ride.CostCheeseType.ToString(),
                MusicalPreference = ride.MusicalPreference.ToString(),
                AnimalPreference = ride.AnimalPreference.ToString(),
                SmokingPreference = ride.SmokingPreference.ToString(),
                TalkingPreference = ride.TalkingPreference.ToString(),
                DriverUserId = ride.DriverUserId,
                DriverFirstName = "Driver First Name", 
                DriverLastName = "Driver Last Name",   
                DriverProfilePicture = "Driver Image URL", 
                Passengers = passengers
            };

            return response;
        }
        public async Task<RideDeleteResponseDTO> DeleteRide(Guid rideId, Guid userId)
        {
            
            var ride = await _rideRepository.GetById(rideId);
            if (ride == null)
            {
                _logger.LogWarning($"Ride with ID {rideId} not found.");
                return new RideDeleteResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "Ride not found."
                };
            }

            
            if (ride.DriverUserId != userId)
            {
                _logger.LogWarning($"User with ID {userId} is not authorized to delete ride with ID {rideId}.");
                return new RideDeleteResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "You are not authorized to delete this ride."
                };
            }

            // DELETERIDE
            var isDeleted = await _rideRepository.Delete(rideId);
            if (!isDeleted)
            {
                return new RideDeleteResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "Failed to delete the ride."
                };
            }

            
            _logger.LogInformation($"Ride with ID {rideId} deleted successfully by user {userId}.");

            
            return new RideDeleteResponseDTO
            {
                IsSuccessful = true,
                Message = "Ride deleted successfully."
            };
        }
        public async Task<Ride> GetRideById(Guid rideId)
        {
            var ride = await _rideRepository.GetById(rideId);
            if (ride == null)
            {
                _logger.LogWarning($"Ride with ID {rideId} not found.");
            }
            return ride; 
        }
    }
}
