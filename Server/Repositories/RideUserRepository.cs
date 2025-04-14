using CarMember_server.Data;
using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarMember_server.Repositories;

public class RideUserRepository : IRepository<RideUser, Guid>
{

    private readonly AppDbContext _db;

    public RideUserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<RideUser> Add(RideUser rideUser)
    {
        await _db.RideUsers.AddAsync(rideUser);
        await _db.SaveChangesAsync();
        return rideUser;
    }


    public async Task<RideUser> Get(Expression<Func<RideUser, bool>> predicate) => await _db.RideUsers.FirstOrDefaultAsync(predicate);

    public async Task<IEnumerable<RideUser>> GetAll() => _db.RideUsers;

    public async Task<IEnumerable<RideUser>> GetAll(Expression<Func<RideUser, bool>> predicate) => _db.RideUsers.Where(predicate);

    public async Task<RideUser> GetById(Guid id) => await _db.RideUsers.FindAsync(id);


    public async Task<bool> Delete(Guid id)
    {
        var rideUser = await GetById(id);
        if (rideUser is null)
            return false;

        _db.RideUsers.Remove(rideUser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<RideUser?> Update(RideUser rideUser)
    {
        var rideUserFromDb = await GetById(rideUser.Id);
        if (rideUserFromDb is null)
            return null;

        if (rideUserFromDb.UserId != rideUser.UserId)
            rideUserFromDb.UserId = rideUser.UserId;

        if (rideUserFromDb.User != rideUser.User)
            rideUserFromDb.User = rideUser.User;

        if (rideUserFromDb.RideId != rideUser.RideId)
            rideUserFromDb.RideId = rideUser.RideId;

        if (rideUserFromDb.Ride != rideUser.Ride)
            rideUserFromDb.Ride = rideUser.Ride;


        await _db.SaveChangesAsync();
        return rideUserFromDb;
    }
}
