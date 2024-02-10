using DemoProject.Data;
using DemoProject.Entities;
using DemoProject.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories
{
    public class UserRespository : IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRespository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(User model)
        {
            await dbContext.Users.AddAsync(model);
            int result = await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteAsync(User model)
        {
            dbContext.Remove(model);
            int result = await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            var users = await dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetAsync(long id)
        {
            var user = await dbContext.Users.FindAsync(id);
            return user;
        }

        public async Task<int> UpdateAsync(User model)
        {
            dbContext.Users.Update(model);  
            int result = await dbContext.SaveChangesAsync();
            return result;
        }
    }
}
