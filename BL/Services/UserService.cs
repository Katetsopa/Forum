using System;
using System.Collections.Generic;
using System.Security.Claims;
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
            try
            {
                ClaimsIdentity claim = null;
                ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
                if (user != null)
                    claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                return claim;
            }
            catch (Exception ex)
            {
                throw new BLLException("",ex);
            }
        }
        
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userDto">user</param>
        /// <returns></returns>
        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            try
            {
                ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
                if (user == null)
                {
                    ApplicationUser appUser = new ApplicationUser { Email = userDto.Email, PasswordHash = userDto.Password, EmailConfirmed = true, PhoneNumberConfirmed = false, TwoFactorEnabled = true, LockoutEnabled = false, AccessFailedCount = 5, Name = userDto.Name, UserName = userDto.UserName };
                    try
                    {
                        await Database.UserManager.CreateAsync(appUser, userDto.Password);
                        await Database.UserManager.AddToRoleAsync(appUser.Id, userDto.Role);
                        await Database.SaveAsync();
                        return new OperationDetails(true, "Successful registration", "");
                    }
                    catch
                    {
                        return new OperationDetails(false, "Registration failed", "");
                    }
                }
                else
                {
                    return new OperationDetails(false, "User with such login already exists", "Email");
                }
            }
            catch(Exception ex)
            {
                throw new BLLException("Can't create user", ex);
            }
        }


        /// <summary>
        /// Create user with list of roles
        /// </summary>
        /// <param name="adminDto">user</param>
        /// <param name="roles">list of roles</param>
        /// <returns></returns>
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            try
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
            catch (Exception ex)
            {
                throw new BLLException("", ex);
            }
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
