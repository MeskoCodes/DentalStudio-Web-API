
namespace Contract
{
    public class AccountDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PasswordResetToken { get; set; }

        public string? EmailConfirmationToken { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime RefreshTokenExpiryTime { get; set; }

        public string? MobileNumber { get; set; }

        public List<string> Roles { get; } = [];
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

        public List<string> Roles { get; } = [];
    }

    public class AccountUpdateDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? LastName { get; set; }

        public string? PasswordResetToken { get; set; }

        public string? EmailConfirmationToken { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime RefreshTokenExpiryTime { get; set; }

        public string? MobileNumber { get; set; }

        public List<string> Roles { get; } = [];
    }
}