using System.Data;
using System.Reflection;
using CarMember_server.Helpers;
using CarMember_server.Models;

namespace CarMember_server.Data;

public class InitialTestData
{

    public static readonly List<User> Users = new List<User>()
    {
        new User{Id= Guid.Parse("49f88bba-7235-44b3-9b03-2396a5d086a8"),
                    FirstName= "Mozart" ,
                    LastName= "Ella",
                    Email=  "mozart.ella@mail.com",
                    Password= "100.Q/V+igOKdbGwclrOUfb5jA==.qTOpw3vNsRyjR6tdTdgGBVunRKE7L4mObirkvEh88To=",  // Mdp: "PA$$W0RD"
                    CreationDate= new DateTime(2025,04,01),
                    Role= Constants.RoleAdmin,
                    VehiculeModelId = Guid.Parse("2eefbb1b-b7b0-4d0d-834a-90ca46f636c2"), // Modele Chevre O Lait
                    PhoneNumber= "+3368856115" ,
                    Gender= "F"
            },

        new User{Id= Guid.Parse("6d4b945a-8e33-4008-af4c-37fc28b893a4"),
                    FirstName= "Igor" ,
                    LastName= "Gonzola",
                    Email=  "igor.gonzolla@mail.com",
                    Password= "100.Q/V+igOKdbGwclrOUfb5jA==.qTOpw3vNsRyjR6tdTdgGBVunRKE7L4mObirkvEh88To=",  // Mdp: "PA$$W0RD"
                    CreationDate= new DateTime(2025,04,02),
                    Role= Constants.RoleUsers,
                    VehiculeModelId= Guid.Parse("66a15c74-4ee7-477d-85b2-a3f084c58142"), // Modele Munster Truck
                    PhoneNumber= "+3361142415" ,
                    Gender= "H"
            },
        new User{Id= Guid.Parse("315dd23f-0155-4196-90eb-f00e2db27014"),
                    FirstName= "Edmond" ,
                    LastName= "d'Or",
                    Email=  "edmond.dor@mail.com",
                    Password= "100.Q/V+igOKdbGwclrOUfb5jA==.qTOpw3vNsRyjR6tdTdgGBVunRKE7L4mObirkvEh88To=",   // Mdp: "PA$$W0RD"
                    CreationDate= new DateTime(2025,04,03),
                    Role= Constants.RoleUsers,
                    PhoneNumber= "+336888815" ,
                    Gender= "H"
            }

    };



    public static readonly List<Ride> Rides = new List<Ride>()
    {
        new Ride{Id= Guid.Parse("95df620f-ae38-4e5a-8894-41332c14c4c5"),
                    DepartureDate=  new DateTime(2025,04,20,   15,00,00)  ,
                    DepartureLocationCity=  "Lille"  ,
                    DepartureLocationAdress=  "3 rue Faidherbe"  ,
                    ArrivalLocationCity= "Paris"   ,
                    ArrivalLocationAdress=  "6 Avenue des Champs Elysées"  ,
                    Duration=  180 ,
                    CostHeight=  1000 ,
                    CostCheeseType=  Cheesetype.Burrata  ,
                    MusicalReference=  MusicalPreference.beaucoup  ,
                    AnimalReference= AnimalPreference.accepte   ,
                    SmokingReference= SmokingReference.accepte  ,
                    TalkingReference= TalkingReference.pipelette   ,
                    DriverUserId= Guid.Parse("6d4b945a-8e33-4008-af4c-37fc28b893a4") // Igor Gonzolla
            },

        new Ride{Id= Guid.Parse("4253b6c2-a9ae-4ea9-97b4-2e88d5348a56"),
                    DepartureDate=  new DateTime(2025,04,16,   09,00,00)  ,
                    DepartureLocationCity=  "Lille"  ,
                    DepartureLocationAdress=  "3 rue Faidherbe, 59000 Lille"  ,
                    ArrivalLocationCity= "Dunkerque"   ,
                    ArrivalLocationAdress=  "4 parvis Victor Hugo, Dunkerque"  ,
                    Duration=  60 ,
                    CostHeight=  600 ,
                    CostCheeseType=  Cheesetype.Beaufort_AOP ,
                    MusicalReference=  MusicalPreference.normal  ,
                    AnimalReference= AnimalPreference.non_accepte   ,
                    SmokingReference= SmokingReference.non_accepte  ,
                    TalkingReference= TalkingReference.peu_bavard   ,
                    DriverUserId= Guid.Parse("315dd23f-0155-4196-90eb-f00e2db27014"), // Edmond d'or
            }
    };


    //public static readonly List<VehiculeModel> VehiculeModels = new List<VehiculeModel>()
    //{
    //        new VehiculeModel{Id= Guid.Parse(""), Category= , Name= "" , NumberOfSeats=   },

    //};



    public static readonly List<Review> Reviews = new List<Review>()
    {
                new Review{Id= Guid.Parse("858eb3be-9850-49a7-9925-02c2c8f5229a"),
                    Score= 5  ,
                    Comment= "Super trajet avec Igor, peu bavard mais très accueuillant ! Edmond."   ,
                    ReviewedUserId = Guid.Parse("6d4b945a-8e33-4008-af4c-37fc28b893a4"),
                    AuthorUserId =  Guid.Parse("315dd23f-0155-4196-90eb-f00e2db27014")
            },
                new Review{Id= Guid.Parse("ff666e12-1475-41a8-ac4f-188eaf83cb6c"),
                    Score= 3  ,
                    Comment=  "Pas sympathique et trop bavard, Mozart est trop vieux jeu ! Igor"  ,
                    ReviewedUserId = Guid.Parse("49f88bba-7235-44b3-9b03-2396a5d086a8"),
                    AuthorUserId =  Guid.Parse("6d4b945a-8e33-4008-af4c-37fc28b893a4")
                }
    };

    public static readonly List<RideUser> RideUsers = new List<RideUser>()
    {
        new RideUser {
            Id = Guid.Parse("729ec28d-8649-4ff4-a3da-74f776e05128"),
            UserId = Guid.Parse("315dd23f-0155-4196-90eb-f00e2db27014"), // Edmond
            RideId = Guid.Parse("95df620f-ae38-4e5a-8894-41332c14c4c5") // Le Lille-Paris avec Igor

        }
    };
}
