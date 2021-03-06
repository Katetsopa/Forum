﻿using System;
using System.Threading.Tasks;
using DAL.Identity;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }
        IThemeRepository ThemeRepository { get; }
        IPostRepository PostRepository { get; } 
        Task SaveAsync();
    }
}
