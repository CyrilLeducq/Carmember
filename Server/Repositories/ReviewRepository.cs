using System.Linq.Expressions;
using CarMember_server.Data;
using CarMember_server.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMember_server.Repositories;

public class ReviewRepository : IRepository<Review, Guid>
{

    private readonly AppDbContext _db;

    public ReviewRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Review> Add(Review review)
    {
        await _db.Reviews.AddAsync(review);
        await _db.SaveChangesAsync();
        return review;
    }
    

    public async Task<Review> Get(Expression<Func<Review, bool>> predicate) => await _db.Reviews.FirstOrDefaultAsync(predicate);

    public async Task<IEnumerable<Review>> GetAll() => await _db.Reviews.ToListAsync();

    public async Task<IEnumerable<Review>> GetAll(Expression<Func<Review, bool>> predicate) => await _db.Reviews.Where(predicate).ToListAsync();

    public async Task<Review> GetById(Guid id) => await _db.Reviews.FindAsync(id);


    public async Task<bool> Delete(Guid id)
    {
        var review = await GetById(id);
        if (review is null)
            return false;

        _db.Reviews.Remove(review);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Review?> Update(Review review)
    {
        var reviewFromDb = await GetById(review.Id);
        if (reviewFromDb is null)
            return null;

        if (reviewFromDb.Score != review.Score)
            reviewFromDb.Score = review.Score;
        
        if (reviewFromDb.Comment != review.Comment)
            reviewFromDb.Comment = review.Comment;
        
        if (reviewFromDb.ReviewedUserId != review.ReviewedUserId)
            reviewFromDb.ReviewedUserId = review.ReviewedUserId;
        
        if (reviewFromDb.ReviewedUser != review.ReviewedUser)
            reviewFromDb.ReviewedUser = review.ReviewedUser;
        
        if (reviewFromDb.AuthorUserId != review.AuthorUserId)
            reviewFromDb.AuthorUserId = review.AuthorUserId;

        if (reviewFromDb.AuthorUser != review.AuthorUser)
            reviewFromDb.AuthorUser = review.AuthorUser;

        await _db.SaveChangesAsync();
        return reviewFromDb;
    }
}
