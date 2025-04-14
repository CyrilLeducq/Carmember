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
        // Implémentation de la méthode CreateRide
        public async Task<RideCreateResponseDTO> CreateRide(RideCreateRequestDTO request)
        {
            // Validation du modèle (validation des annotations DataAnnotations)
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(request); // Contexte de validation
           
            // L'utilisateur qui crée le trajet est celui qui fait la requête, donc on utilise son ID comme DriverUserId
            var driver = await _userRepository.GetById(request.DriverUserId);
            if (driver == null)
            {
                _logger.LogWarning($"User with ID {request.DriverUserId} not found.");
                throw new InvalidOperationException("User not found.");
            }

            // Création du trajet
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

            // Sauvegarde du trajet dans la base de données
            var createdRide = await _rideRepository.Add(ride);

            // Log de création réussie
            _logger.LogInformation($"Ride with ID {createdRide.Id} created successfully by user {request.DriverUserId}.");

            // Construction de la réponse
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
        // Implémentation de la méthode UpdateRide
        public async Task<RideUpdateResponseDTO> UpdateRide(Guid rideId, RideUpdateRequestDTO request)
        {
            // Vérification de l'existence du trajet
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

            // Mise à jour des informations du trajet
            existingRide.DepartureDate = request.DepartureDate;
            existingRide.DepartureLocationCity = request.DepartureLocationCity;
            existingRide.DepartureLocationAdress = request.DepartureLocationAddress;
            existingRide.ArrivalLocationCity = request.ArrivalLocationCity;
            existingRide.ArrivalLocationAdress = request.ArrivalLocationAddress;
            existingRide.Duration = (int)request.Duration.TotalMinutes;  // Conversion de la durée en minutes
            existingRide.CostHeight = request.CheeseCostInGrams;
            existingRide.CostCheeseType = request.CheeseType;
            existingRide.MusicalPreference = request.MusicalPreference;
            existingRide.AnimalPreference = request.AnimalPreference;
            existingRide.SmokingPreference = request.SmokingPreference;
            existingRide.TalkingPreference = request.TalkingPreference;

            // Sauvegarde des modifications dans la base de données
            var updatedRide = await _rideRepository.Update(existingRide);

            // Log de mise à jour réussie
            _logger.LogInformation($"Ride with ID {updatedRide.Id} updated successfully.");

            // Construction de la réponse
            var response = new RideUpdateResponseDTO
            {
                IsSuccessful = true,
                UpdatedRide = updatedRide // Renvoi du trajet mis à jour
            };

            return response;
        }
        public async Task<RideViewResponseDTO> ViewRideDetails(RideViewRequestDTO request)
        {
            // Récupérer le trajet par ID à partir de la requête
            var ride = await _rideRepository.GetById(request.RideId);  // Utilisation de request.RideId pour récupérer le trajet
            if (ride == null)
            {
                _logger.LogWarning($"Ride with ID {request.RideId} not found.");
                return new RideViewResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "Ride not found."
                };
            }

            // Récupérer les passagers associés à ce trajet
            var passengers = await _rideRepository.GetPassengersByRideId(request.RideId);

            // Préparer la réponse DTO
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
                DriverFirstName = "Driver First Name", // À récupérer si nécessaire
                DriverLastName = "Driver Last Name",   // À récupérer si nécessaire
                DriverProfilePicture = "Driver Image URL", // À récupérer si nécessaire
                Passengers = passengers
            };

            return response;
        }
        public async Task<RideDeleteResponseDTO> DeleteRide(Guid rideId, Guid userId)
        {
            // Récupérer le trajet par ID
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

            // Vérifier si l'utilisateur qui effectue la requête est celui qui a créé le trajet
            if (ride.DriverUserId != userId)
            {
                _logger.LogWarning($"User with ID {userId} is not authorized to delete ride with ID {rideId}.");
                return new RideDeleteResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "You are not authorized to delete this ride."
                };
            }

            // Supprimer le trajet
            var isDeleted = await _rideRepository.Delete(rideId);
            if (!isDeleted)
            {
                return new RideDeleteResponseDTO
                {
                    IsSuccessful = false,
                    ErrorMessage = "Failed to delete the ride."
                };
            }

            // Log de suppression réussie
            _logger.LogInformation($"Ride with ID {rideId} deleted successfully by user {userId}.");

            // Retourner une réponse de succès
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
