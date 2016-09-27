using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Entity;
using System.Data.Entity.Validation;

namespace DAL.Repository
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ForumContext _db;

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IClientManager _clientManager;
        private IThemeRepository _themeRepository;
        private IPostRepository _postRepository;

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new ForumContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _clientManager = new ClientManager(_db);
            _themeRepository = new ThemeRepository(_db);
            _postRepository = new PostRepository(_db);
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }

        public IClientManager ClientManager
        {
            get { return _clientManager; }
        }

        public IThemeRepository ThemeRepository
        {
            get { return _themeRepository; }
        }

        public IPostRepository PostRepository
        {
            get { return _postRepository; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();

                }
                this.disposed = true;
            }
        }

        public async  Task SaveAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch 
            {
                throw new Exception();
            }
        }
    }
}
