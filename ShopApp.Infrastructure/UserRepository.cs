using Microsoft.EntityFrameworkCore;
using ShopApp.Core.Entities;
using ShopApp.Database;

namespace ShopApp.Infrastructure
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllWithBsAsync();
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllWithBsAsync()
        {
            return await _context.Users.Include(user => user.Products).ToListAsync();
        }
    }
}
