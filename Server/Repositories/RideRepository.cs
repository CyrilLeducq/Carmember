using System.Linq.Expressions;
using CarMember_server.Data;
using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMember_server.Repositories
{
    public class RideRepository : IRepository<Ride, Guid>
    {
        private readonly AppDbContext _db;

        public RideRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Ride> Add(Ride ride)
        {
            await _db.Rides.AddAsync(ride);
            await _db.SaveChangesAsync();
            return ride;
        }

        //Methode pour récupérer un trajet par son ID
        public async Task<Ride> GetById(Guid id)
        {
            return await _db.Rides.FindAsync(id);
        }

        //Methode pour récupérer un trajet selon son un prédicat (critère de recherche)
        public async Task<Ride> Get(Expression<Func<Ride, bool>> predicate)
        {
            return await _db.Rides.FirstOrDefaultAsync(predicate);
        }

        //Méthode pour récupérer tous les trajets
        public async Task<IEnumerable<Ride>> GetAll()
        {
            return await _db.Rides.ToListAsync();
        }

        //Methode pour récupérer les trajet selon un predicat
        public async Task<IEnumerable<Ride>> GetAll(Expression<Func<Ride, bool>> predicate)
        {
            return await _db.Rides.Where(predicate).ToListAsync();
        }

        //Méthode pour mettre à jour un trajet
        public async Task<Ride?> Update(Ride ride)
        {
            var rideFromDb = await GetById(ride.Id);
            if (rideFromDb == null)
                return null;

            if (rideFromDb.DepartureDate != ride.DepartureDate)
                rideFromDb.DepartureDate = ride.DepartureDate;

            if (rideFromDb.DriverUserId != ride.DriverUserId)
                rideFromDb.DriverUserId = ride.DriverUserId;

            if (rideFromDb.DepartureLocationCity != ride.DepartureLocationCity)
                rideFromDb.DepartureLocationCity = ride.DepartureLocationCity;

            if (rideFromDb.DepartureLocationAdress != ride.DepartureLocationAdress)
                rideFromDb.DepartureLocationAdress = ride.DepartureLocationAdress;

            if (rideFromDb.ArrivalLocationCity != ride.ArrivalLocationCity)
                rideFromDb.ArrivalLocationCity = ride.ArrivalLocationCity;

            if (rideFromDb.ArrivalLocationAdress != ride.ArrivalLocationAdress)
                rideFromDb.ArrivalLocationAdress = ride.ArrivalLocationAdress;

            if (rideFromDb.Duration != ride.Duration)
                rideFromDb.Duration = ride.Duration;

            if (rideFromDb.CostHeight != ride.CostHeight)
                rideFromDb.CostHeight = ride.CostHeight;

            if (rideFromDb.CostCheeseType != ride.CostCheeseType)
                rideFromDb.CostCheeseType = ride.CostCheeseType;

            if (rideFromDb.MusicalPreference != ride.MusicalPreference)
                rideFromDb.MusicalPreference = ride.MusicalPreference;

            if (rideFromDb.AnimalPreference != ride.AnimalPreference)
                rideFromDb.AnimalPreference = ride.AnimalPreference;

            if (rideFromDb.SmokingPreference != ride.SmokingPreference)
                rideFromDb.SmokingPreference = ride.SmokingPreference;

            if (rideFromDb.TalkingPreference != ride.TalkingPreference)
                rideFromDb.TalkingPreference = ride.TalkingPreference;

            await _db.SaveChangesAsync();
            return rideFromDb;
        }
        //Méthode pour supprimer un trajet
        public async Task<bool> Delete(Guid id)
        {
            var ride = await GetById(id);
            if (ride == null)
                return false;

            _db.Rides.Remove(ride);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
