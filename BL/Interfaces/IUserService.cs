using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using System.Security.Claims;
using BLL.Infrastructure;

namespace BLL.Intrfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
