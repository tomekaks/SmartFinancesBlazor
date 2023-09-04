using SmartFinances.Application.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginRequest loginDto);
        Task<RegistrationResponse> Register(RegisterRequest registerDto);   
    }
}
