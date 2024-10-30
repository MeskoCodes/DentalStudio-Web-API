global using Contract;
global using Domain.Entities;
global using Domain.Repositories;
global using Mapster;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Services.Abstractions;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net;
global using System.Net.Mail;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
using Services.Common;

namespace Services
{
    public class ServiceManager(
        IRepositoryManager repositoryManager,
        UserManager<Account> userManager,
        RoleManager<AccountRole> roleManager,
        ITokenService tokenService) : IServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService = new(() => new AccountService(repositoryManager, userManager, roleManager, tokenService));

        private readonly Lazy<IProductService> _lazyProductServicee = new(() => new ProductService(repositoryManager));

        private readonly Lazy<ICategoryService> _lazyCategoryService = new(() => new CategoryService(repositoryManager));


        public IAccountService AccountService => _lazyAccountService.Value;

        public IProductService ProductService => _lazyProductServicee.Value;

        public ICategoryService CategoryService => _lazyCategoryService.Value;
    }
}