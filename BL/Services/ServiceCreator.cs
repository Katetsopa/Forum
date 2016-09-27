using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Intrfaces;
using DAL.Repository;

namespace BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        //UserService взаимодействует с БД при помощи объекта IdentityUnitOfWork
        //Фабричный метод, который создает сервис UserService
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
