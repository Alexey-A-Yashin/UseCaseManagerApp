using EntitiesUCM;

namespace DbUCM.Repositories
{
    public interface IUsersRepository
    {
        public Task<UserUCM> Create(UserUCM user);
        public Task<int> Delete(int id);
        public Task<UserUCM> Update(UserUCM user);
        public Task<UserUCM> Get(int id);
        public Task<IEnumerable<UserUCM>> GetAll();
    }
}