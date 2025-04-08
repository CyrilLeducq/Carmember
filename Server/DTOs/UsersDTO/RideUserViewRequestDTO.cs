using CarMember_server.Models;
using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.UsersDTO
{
    public class RideRegisterRequestDTO
    {
        public DateTime? DepartureDate { get; set; } 

        public string DepartureLocationCity { get; set; } 

        public string DepartureLocationAdress { get; set; } 

        public string ArrivalLocationCity { get; set; } 

        public string ArrivalLocationAdress { get; set; } 

        public int Duration { get; set; } 

        public int CostHeight { get; set; } 

        public string CostCheeseType { get; set; } 

        public MusicalPreference MusicalReference { get; set; } 

        public AnimalPreference AnimalReference { get; set; } 

        public SmokingReference SmokingReference { get; set; } 

        public TalkingReference TalkingReference { get; set; } 
    }
}
