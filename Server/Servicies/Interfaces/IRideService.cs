using CarMember_server.DTOs.RidesDTO;
using CarMember_server.Models;

namespace CarMember_server.Servicies.Interfaces
{
    public interface IRideService
    {
        Task<RideViewResponseDTO> ViewRideDetails(RideViewRequestDTO request);
        Task<RideCreateResponseDTO> CreateRide(RideCreateRequestDTO request);
        Task<RideUpdateResponseDTO> UpdateRide(Guid rideId, RideUpdateRequestDTO request);
        Task<RideDeleteResponseDTO> DeleteRide(Guid rideId, Guid userId);

        Task<Ride> GetRideById(Guid rideId);
    }
}
