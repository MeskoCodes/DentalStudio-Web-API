global using Contract;
global using Domain.Entities;
global using Mapster;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.Extensions.Configuration;
global using Microsoft.IdentityModel.Tokens;
global using Services.Abstractions;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
using Domain.Repositories.Common;
using Services.Abstractions.Billing;
using Services.Abstractions.Scheduling;
using Services.Billing;
using Services.Scheduling;

namespace Services
{
    public class ServiceManager(
        IRepositoryManager repositoryManager,
        UserManager<Account> userManager,
        RoleManager<AccountRole> roleManager,
        ITokenService tokenService) : IServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService = new(() => new AccountService(repositoryManager, userManager, roleManager, tokenService));
        private readonly Lazy<IPatientService> _lazyPatientService = new(() => new PatientService(repositoryManager));
        private readonly Lazy<IEmployeeService> _lazyEmployeeService = new(() => new EmployeeService(repositoryManager));
        private readonly Lazy<ITreatmentService> _lazyTreatmentService = new(() => new TreatmentService(repositoryManager));
        private readonly Lazy<IPaymentService> _lazyPaymentService = new(() => new PaymentService(repositoryManager));
        private readonly Lazy<IInvoiceService> _lazyInvoiceService = new(() => new InvoiceService(repositoryManager));
        private readonly Lazy<IAppointmentService> _lazyAppointmentService = new(() => new AppointmentService(repositoryManager));


        public IAccountService AccountService => _lazyAccountService.Value;

        public IPatientService PatientService => _lazyPatientService.Value;

        public IEmployeeService EmployeeService => _lazyEmployeeService.Value;

        public ITreatmentService TreatmentService => _lazyTreatmentService.Value;

        public IPaymentService PaymentService => _lazyPaymentService.Value;

        public IInvoiceService InvoiceService => _lazyInvoiceService.Value;

        public IAppointmentService AppointmentService => _lazyAppointmentService.Value;
    }
}