using CarMember_server.Data;
using System.Linq.Expressions;
using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMember_server.Repositories;

public class VehiculeModelRepository : IRepository <VehiculeModel , Guid>
{
    private readonly AppDbContext _db;

    public VehiculeModelRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<VehiculeModel> Add(VehiculeModel vehiculeModel)
    {
        await _db.VehiculeModels.AddAsync(vehiculeModel);
        await _db.SaveChangesAsync();
        return vehiculeModel;
    }

    public async Task<VehiculeModel?> GetById(Guid id) => await _db.VehiculeModels.FirstOrDefaultAsync(v => v.Id == id);

    public async Task<VehiculeModel?> Get(Expression<Func<VehiculeModel, bool>> predicate) => await _db.VehiculeModels.FirstOrDefaultAsync(predicate);

    public async Task<IEnumerable<VehiculeModel>> GetAll() => await _db.VehiculeModels.ToListAsync();

    public async Task<IEnumerable<VehiculeModel>> GetAll(Expression<Func<VehiculeModel, bool>> predicate) => await _db.VehiculeModels.Where(predicate).ToListAsync();

    public async Task<VehiculeModel?> Update(VehiculeModel vehiculeModel)
    {
        var vehiculeModelFromDb = await GetById(vehiculeModel.Id);
        if (vehiculeModelFromDb is null)
            return null;

        if (vehiculeModelFromDb.Category != vehiculeModel.Category)
            vehiculeModelFromDb.Category = vehiculeModel.Category;

        if (vehiculeModelFromDb.Name != vehiculeModel.Name)
            vehiculeModelFromDb.Name = vehiculeModel.Name;

        if (vehiculeModelFromDb.NumberOfSeats != vehiculeModel.NumberOfSeats)
            vehiculeModelFromDb.NumberOfSeats = vehiculeModel.NumberOfSeats;

        if (vehiculeModelFromDb.Users != vehiculeModel.Users)
            vehiculeModelFromDb.Users = vehiculeModel.Users;

        await _db.SaveChangesAsync();
        return vehiculeModelFromDb;
    }

    public async Task<bool> Delete(Guid id)
    {
        var vehiculeModel = await GetById(id);
        if (vehiculeModel is null)
            return false;

        _db.VehiculeModels.Remove(vehiculeModel);
        await _db.SaveChangesAsync();
        return true;
    }
}
