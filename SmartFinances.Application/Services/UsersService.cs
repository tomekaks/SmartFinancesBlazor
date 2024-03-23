using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Queries;
using SmartFinances.Application.Features.Users.Dtos;
using SmartFinances.Application.Features.Users.Requests.Commands;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Core.Data;

namespace SmartFinances.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UsersService(UserManager<ApplicationUser> userManager, IMapper mapper, IMediator mediator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId);

            await _userManager.ChangePasswordAsync(applicationUser, oldPassword, newPassword);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            var testUsers = await _userManager.GetUsersInRoleAsync("TestUser");

            var allUsers = users.Concat(testUsers);
            

            return _mapper.Map<List<UserDto>>(allUsers);
        }

        public async Task<UserDto> GetPersonalDataAsync(string userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId);

            return _mapper.Map<UserDto>(applicationUser);
        }

        public async Task<UserDto> GetUserWithAccountsAsync(string userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId);
            var accounts = await _mediator.Send(new GetUsersTransactionalAccountsRequest { UserId = userId });

            var userDto = _mapper.Map<UserDto>(applicationUser);
            userDto.Accounts = accounts;

            return userDto;
        }

        public async Task UpdateUsersStatusAsync(UsersStatusDto statusDto)
        {
            await _mediator.Send(new UpdateUsersStatusCommand { UsersStatusDto= statusDto });
        }

    }
}
