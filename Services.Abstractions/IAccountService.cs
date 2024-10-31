using Contract;
using Contract.Account;
using Contract.Authentification;

namespace Services.Abstractions;

public interface IAccountService
{
    Task<IEnumerable<AccountDto>> GetAll(CancellationToken cancellationToken = default);

    Task<AccountDto> GetById(string accountId, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Register(RegistrationDto registrationDto, CancellationToken cancellationToken = default);

    Task<AuthenticationDto> Login(LoginDto loginDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> ChangePassword(string id, ChangePasswordDto changePassword);

    Task<bool> ForgotPasword(ForgotPasswordDto forgotPasswordDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> ResetPasword(ResetPasswordDto resetPasswordDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> ConfirmEmail(ConfirmEmailDto confirmEmailDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Create(AccountCreateDto accountDto, CancellationToken cancellationToken = default);

    Task<GeneralResponseDto> Update(string accountId, AccountUpdateDto account,
        CancellationToken cancellationToken = default);

    Task Delete(string accountId, CancellationToken cancellationToken = default);
}
