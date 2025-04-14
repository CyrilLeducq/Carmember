using System.ComponentModel.DataAnnotations;
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
                MusicalReference = request.MusicalPreference,
                AnimalReference = request.AnimalPreference,
                SmokingReference = request.SmokingPreference,
                TalkingReference = request.TalkingPreference
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
                MusicalPreference = createdRide.MusicalReference.ToString(),
                AnimalPreference = createdRide.AnimalReference.ToString(),
                SmokingPreference = createdRide.SmokingReference.ToString(),
                TalkingPreference = createdRide.TalkingReference.ToString()
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
            existingRide.MusicalReference = request.MusicalPreference;
            existingRide.AnimalReference = request.AnimalPreference;
            existingRide.SmokingReference = request.SmokingPreference;
            existingRide.TalkingReference = request.TalkingPreference;

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
            throw new NotImplementedException("Méthode ViewRideDetails à implémenter.");
        }
    }
}
