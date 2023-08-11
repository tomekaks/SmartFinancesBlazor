using SmartFinances.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Services
{
    public interface IUsersService
    {
        Task<UserDto> GetPersonalDataAsync(string userId);
        Task ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserWithAccountsAsync(string userId);
        Task UpdateUsersStatusAsync(UsersStatusDto statusDto);
    }
}
