using DAL.Entity;
using System;

namespace DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ApplicationUser item);
    }
}
