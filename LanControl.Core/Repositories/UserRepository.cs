using LanControl.Core.Models;
using LanControl.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanControl.Core.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbContext _dbContext;
    
    protected UserRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User?> GetById(int id)
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
}