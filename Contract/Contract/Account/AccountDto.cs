using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Account
{
    public class AccountDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? PasswordResetToken { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string? MobileNumber { get; set; }
        public List<string> Roles { get; } = new List<string>();
    }
}

    public class AccountCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordResetToken { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string? MobileNumber { get; set; }
        public List<string> Roles { get; } = new List<string>();
    }


    public class AccountUpdateDto
    {
        public string Id { get; set; } = string.Empty; // ID korisnika
        public string FirstName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? LastName { get; set; }
        public string? PasswordResetToken { get; set; }
        public string? EmailConfirmationToken { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string? MobileNumber { get; set; }
        public List<string> Roles { get; } = new List<string>();
    }


