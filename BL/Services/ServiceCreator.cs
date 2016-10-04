using BLL.Interfaces;
using BLL.Intrfaces;
using DAL.Repository;

namespace BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }

        public IThemeService CreateThemeService(string connection)
        {
            return new ThemeService(new IdentityUnitOfWork(connection));
        }

        public IPostService CreatePostService(string connection)
        {
            return new PostService(new IdentityUnitOfWork(connection));
        }
    }
}
