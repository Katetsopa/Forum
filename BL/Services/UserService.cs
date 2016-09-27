using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Intrfaces;
using DAL.Interfaces;
using DAL.Entity;
using Microsoft.AspNet.Identity;

namespace BLL.Services
{
    public class UserService : IUserService
    {

        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {                
                // создаем профиль клиента  //EmailConfirmed bool //PhoneNumberConfirmed bool //TwoFactorEnabled bool  //LockoutEnabled bool //AccessFailedCount int //UserName string
                ApplicationUser appUser = new ApplicationUser { Email=userDto.Email, PasswordHash = userDto.Password, EmailConfirmed = true, PhoneNumberConfirmed=false, TwoFactorEnabled=true, LockoutEnabled=false, AccessFailedCount = 5,  Name = userDto.Name ,  UserName = userDto.UserName };
                try
                {
                    await Database.UserManager.CreateAsync(appUser, userDto.Password);

                    await Database.UserManager.AddToRoleAsync(appUser.Id, userDto.Role);

                    await Database.SaveAsync();
                    return new OperationDetails(true, "Регистрация успешно пройдена", "");
                }
                catch
                {
                    return new OperationDetails(false, "Проблемы при регистрации", "");
                }
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }
    }
}
