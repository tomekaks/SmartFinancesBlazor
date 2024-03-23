using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Exceptions;
using SmartFinances.Application.Features.Accounts.Dtos;
using SmartFinances.Application.Features.Accounts.Requests.Commands;
using SmartFinances.Application.Features.TransactionalAccounts.Dtos;
using SmartFinances.Application.Features.TransactionalAccounts.Requests.Commands;
using SmartFinances.Application.Features.Users.Dtos;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Core.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartFinances.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper,
                           IMediator mediator, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mediator = mediator;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.UserName);
            if (user == null) 
            {
                throw new NotFoundException(loginRequest.UserName, loginRequest.UserName);
            }

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!isPasswordValid)
            {
                throw new BadRequestException("Invalid Credentials");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new AuthResponse()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

            return response;
        }


        public async Task<RegistrationResponse> Register(RegisterRequest registerRequest)
        {
            var user = _mapper.Map<ApplicationUser>(registerRequest);
            user.NumberOfAccounts = 1;
            var result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (!result.Succeeded)
            {
                return new RegistrationResponse();
            }

            await _userManager.AddToRoleAsync(user, "User");

            var createTransactionalAccountDto = new CreateTransactionalAccountDto()
            {
                UserId = user.Id,
                Type = Constants.MAINACCOUNT
            };

            await _mediator.Send(new CreateTransactionalAccountCommand { AccountDto = createTransactionalAccountDto });

            //tomek

            //var createAccountDto = new CreateAccountDto()
            //{
            //    UserId = user.Id,
            //    Type = 1
            //};

            //await _mediator.Send(new CreateAccountCommand { CreateAccountDto = createAccountDto});    

            return new RegistrationResponse()
            {
                UserId = user.Id
            };
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }
}
