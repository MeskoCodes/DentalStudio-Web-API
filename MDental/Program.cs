using Contract.Billing;
using Domain.Entities;
using Domain.Repositories.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracija servisa
ConfigureServices(builder.Services, builder.Configuration);
ConfigureDatabase(builder.Services, builder.Configuration);
ConfigureJwtAuthentication(builder.Services, builder.Configuration);
ConfigureCors(builder.Services);

var app = builder.Build();

// Konfiguracija aplikacije
ConfigureApp(app, builder.Environment);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IPatientService, PatientService>();
    services.AddScoped<IAppointmentService, AppointmentService>();
    services.AddScoped<IInvoiceService, InvoiceService>();
    services.AddScoped<IPaymentService, PaymentService>(); ;
    
    services.AddScoped<IRepositoryManager, RepositoryManager>();
    services.AddScoped<IServiceManager, ServiceManager>();
    services.AddScoped<ITokenService, TokenService>();

    services.AddIdentity<Account, AccountRole>(opt =>
    {
        opt.Password.RequiredLength = 7;
        opt.Password.RequireDigit = true;
        opt.Password.RequireUppercase = true;
        opt.SignIn.RequireConfirmedEmail = true;
    })
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();
}

void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContextPool<DataContext>(options =>
    {
        options.UseMySql(configuration.GetConnectionString("MainDB"),
            new MySqlServerVersion(new Version(8, 0, 21)),
            mysqlOptions =>
            {
                mysqlOptions.EnableRetryOnFailure(1, TimeSpan.FromSeconds(5), null);
            });
    });
}

void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
{
    var jwtSettings = configuration.GetSection("JwtSettings");

    services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["validIssuer"],
            ValidAudience = jwtSettings["validAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
        };
    });
}

void ConfigureCors(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy("Mdental", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}

void ConfigureApp(WebApplication app, IHostEnvironment environment)
{
    app.UseCors("Mdental");

    if (environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}
