using CarMember_server.Models;

namespace CarMember_server.Data;

public class InitialData
{

    public static readonly List<VehiculeModel> VehiculeModels = new List<VehiculeModel>()
    {
        new VehiculeModel{Id= Guid.Parse("2eefbb1b-b7b0-4d0d-834a-90ca46f636c2"), Category=VehiculeCategory.Car , Name= "Chèvre-O-lait" , NumberOfSeats= 5  },
        new VehiculeModel{Id= Guid.Parse("66a15c74-4ee7-477d-85b2-a3f084c58142"), Category=VehiculeCategory.MonsterTruck , Name= "Munster-Truck", NumberOfSeats= 4  }
    };

    //public static readonly List<User> Users = new List<User>()
    //{
    //    new User{Id= Guid.Parse("2eefbb1b-b7b0-4d0d-834a-90ca46f636c2"), Category=VehiculeCategory.Car , Name= "Chèvre-O-lait" , NumberOfSeats= 5  }

    //};

    //public static readonly List<Ride> Rides = new List<Ride>()
    //{
    //    new Ride{Id= Guid.Parse("2eefbb1b-b7b0-4d0d-834a-90ca46f636c2"), Category=VehiculeCategory.Car , Name= "Chèvre-O-lait" , NumberOfSeats= 5  }
    //};

}
