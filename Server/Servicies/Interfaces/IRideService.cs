using CarMember_server.DTOs.RidesDTO;

namespace CarMember_server.Servicies.Interfaces
{
    public interface IRideService
    {
        Task<RideViewResponseDTO> ViewRideDetails(RideViewRequestDTO request);
        Task<RideCreateResponseDTO> CreateRide(RideCreateRequestDTO request);
        Task<RideUpdateResponseDTO> UpdateRide(Guid rideId, RideUpdateRequestDTO request);
        //Task<RideDeleteResponseDTO> DeleteRide(RideDeleteRequestDTO request);
    }
}
