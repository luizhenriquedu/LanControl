using LanControl.Core.Database;
using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanControl.Core.Repositories;

public class UserRepository(DatabaseContext dbContext) : IUserRepository
{
    private readonly DatabaseContext _dbContext = dbContext;
    
    public async Task<User?> GetById(string id)
    {
        return await _dbContext.Set<User>().FindAsync(id);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _dbContext.Set<User>().ToListAsync();
    }

    public void Update(User user)
    {
        _dbContext.Set<User>().Update(user);
    }

    public async ValueTask<int> Commit()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async ValueTask Add(User user)
    {
        await _dbContext.Set<User>().AddAsync(user);
    }

    public async ValueTask<bool> ExistsByEmail(string email)
    {
        return await _dbContext.Set<User>().AnyAsync(user => user.Email == email);
    }
    public async ValueTask<bool> ExistsById(string id)
    {
        return await _dbContext.Set<User>().AnyAsync(user => user.Id == id);
    }
}