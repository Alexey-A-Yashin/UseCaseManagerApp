using EntitiesUCM;
using Microsoft.EntityFrameworkCore;

namespace DbUCM.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
            => _context = context;

        public async Task<UserUCM> Create(UserUCM user)
        {
            var addedUser = _context.UsersUCM.Add(user);
            await _context.SaveChangesAsync();
            return addedUser.Entity;
        }

        public async Task<int> Delete(int id)
        {
            var findedUser = await _context.UsersUCM.FirstOrDefaultAsync(x => x.id == id);

            if (findedUser != null)
            {
                _context.UsersUCM.Remove(findedUser);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<UserUCM> Update(UserUCM user)
        {
            _context.UsersUCM.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserUCM> Get(int id)
        {
            var findedUser = await _context.UsersUCM.FirstOrDefaultAsync(x => x.id == id);

            if (findedUser != null)
            {
                return findedUser;
            }
            return new UserUCM();
        }

        public async Task<IEnumerable<UserUCM>> GetAll()
        {
            return await _context.UsersUCM.ToListAsync();
        }
    }
}