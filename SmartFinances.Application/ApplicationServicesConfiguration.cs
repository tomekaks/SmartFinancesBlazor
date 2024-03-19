using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Features.Accounts.Factories;
using SmartFinances.Application.Features.Contacts.Factories;
using SmartFinances.Application.Features.Expenses.Factories;
using SmartFinances.Application.Features.ExpenseTypes.Factories;
using SmartFinances.Application.Features.MonthlySummaries.Factories;
using SmartFinances.Application.Features.RegularExpenses.Factories;
using SmartFinances.Application.Features.SavingsAccounts.Factories;
using SmartFinances.Application.Features.Transfers.Factories;
using SmartFinances.Application.Features.YearlySummaries.Factories;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Application.Services;
using System.Reflection;
using System.Text;

namespace SmartFinances.Application
{
    public static class ApplicationServicesConfiguration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddScoped<IAccountFactory, AccountFactory>();
            services.AddScoped<IExpenseFactory, ExpenseFactory>();
            services.AddScoped<IRegularExpenseFactory, RegularExpenseFactory>();
            services.AddScoped<ITransferFactory, TransferFactory>();
            services.AddScoped<IContactFactory, ContactFactory>();
            services.AddScoped<IExpenseTypeFactory, ExpenseTypeFactory>();
            services.AddScoped<IYearlySummaryFactory, YearlySummaryFactory>();
            services.AddScoped<IMonthlySummaryFactory, MonthlySummaryFactory>();
            services.AddScoped<ISavingsAccountFactory, SavingsAccountFactory>();
            //services.AddScoped<ITransactionalAccountFactory, TransactionalAccountFactory>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            return services;
        }
    }
}
