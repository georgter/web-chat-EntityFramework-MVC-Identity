using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebChat.BLL.DTO;
using WebChat.BLL.Infrastructure;
using WebChat.BLL.Interfaces;
using WebChat.DAL.Entities;

namespace WebChat.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
        
    }
}
