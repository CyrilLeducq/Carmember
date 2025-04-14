using System.Linq.Expressions;
using CarMember_server.Data;
using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMember_server.Repositories
{
    public class UserRepository : IRepository<User, Guid>
    {
        
            private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        //Méthode pour ajouter un nouvel utilisateur
        public async Task<User> Add(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        //Méthode pour récupérer un utilisateur par son id
        public async Task<User> GetById(Guid id)
        {
            return await _db.Users.FindAsync(id);
        }

        //Methode pour récupérer un utilisateur selon son un prédicat (critère de recherche)
        public async Task<User> Get(Expression<Func<User, bool>>predicate)
        {
            return await _db.Users.FirstOrDefaultAsync(predicate);
        }

        //Méthode pour récupérer tous les utilisateurs
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        //Methode pour récupérer les utilisateurs selon un predicat
        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>>predicate)
        {
            return await _db.Users.Where(predicate).ToListAsync();
        }

        //Méthode pour mettre à jour un utilisateur
        public async Task<User?> Update(User user)
        {
            var userFromDb = await GetById(user.Id);
            if (userFromDb == null) 
                return null;

            if(userFromDb.LastName != user.LastName)
                userFromDb.LastName = user.LastName;

            if(userFromDb.FirstName != user.FirstName)
                userFromDb.FirstName = user.FirstName;

            if(userFromDb.Email != user.Email)
                userFromDb.Email = user.Email;

            if(userFromDb.PhoneNumber != user.PhoneNumber)
                userFromDb.PhoneNumber = user.PhoneNumber;

            if(userFromDb.ProfilePicture != user.ProfilePicture)
                userFromDb.ProfilePicture = user.ProfilePicture;

            if(userFromDb.Password != user.Password)
                userFromDb.Password = user.Password;

            if(userFromDb.PasswordSalt != user.PasswordSalt)
                userFromDb.PasswordSalt = user.PasswordSalt;

            if(userFromDb.Gender != user.Gender)
                userFromDb.Gender = user.Gender;

            if(userFromDb.Role != user.Role)
                userFromDb.Role = user.Role;

            await _db.SaveChangesAsync();
            return userFromDb;
        }

        //Méthode pour supprimer un utilisateur
        public async Task<bool> Delete(Guid id)
        {
            var user = await GetById(id);
            if (user == null)
                return false;

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}


