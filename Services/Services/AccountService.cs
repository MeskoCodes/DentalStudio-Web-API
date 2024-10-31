using Contract.Account;
using Contract.Authentification;
using Domain.Repositories.Common;

namespace Services
{
    public sealed class AccountService(
        IRepositoryManager repositoryManager,
        UserManager<Account> userManager,
        RoleManager<AccountRole> roleManager,
        ITokenService tokenService) : IAccountService
    {

        #region Auth

        public async Task<GeneralResponseDto> Register(RegistrationDto registrationDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var userExist = await userManager.FindByEmailAsync(registrationDto.Email);

                if (userExist != null)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "That email is already in use."
                    };
                }

                var accountForCreation = registrationDto.Adapt<Account>();
                accountForCreation.UserName = accountForCreation.Email;
                accountForCreation.EmailConfirmed = true;
                var response = await userManager.CreateAsync(accountForCreation, registrationDto.Password);

                if (!response.Succeeded)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = response.Errors.ToString()
                    }!;
                }

                var createdUser = await userManager.FindByEmailAsync(accountForCreation.Email);
                await userManager.AddToRoleAsync(createdUser, registrationDto.Role);
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto
                {
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                }!;
            }
        }

        public async Task<GeneralResponseDto> ChangePassword(string id, ChangePasswordDto changePassword)
        {
            var findUser = await userManager.FindByEmailAsync(changePassword.Email);
            if (findUser == null)
                return new GeneralResponseDto { IsSuccess = false, Message = "Benutzer nicht gefunden" };

            var checkPass = await userManager.CheckPasswordAsync(findUser, changePassword.OldPassword);
            if (!checkPass)
                return new GeneralResponseDto { IsSuccess = false, Message = "Passwort stimmt nicht überein" };

            var hashPassword = await userManager.ChangePasswordAsync(findUser, changePassword.OldPassword, changePassword.NewPassword);

            return hashPassword.Succeeded
                ? new GeneralResponseDto { IsSuccess = true, Message = "Das Passwort wurde erfolgreich geändert." }
                : new GeneralResponseDto { IsSuccess = false, Message = "Ein Fehler ist aufgetreten." };
        }

        public async Task<AuthenticationDto> Login(LoginDto loginDto, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            //if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
            //    return (new AuthenticationDto { ErrorMessage = "Invalid Authentication" });
            if (user == null)
                return (new AuthenticationDto { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = tokenService.GetSigningCredentials();
            var claims = await tokenService.GetClaims(user);
            var tokenOptions = tokenService.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            user.RefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            await userManager.UpdateAsync(user);
            return new AuthenticationDto
            {
                IsSuccessful = true,
                AccessToken = token,
                RefreshToken = user.RefreshToken,
                AccountFirstName = user.FirstName,
                AccountId = user.Id
            };
        }

        public async Task<bool> ForgotPasword(ForgotPasswordDto forgotPasswordDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(forgotPasswordDto.Email);
                if (user == null)
                {
                    return false;
                }

                var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                user.PasswordResetToken = resetToken;
                await repositoryManager.UnitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<GeneralResponseDto> ResetPasword(ResetPasswordDto resetPasswordDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(resetPasswordDto.Email);
                if (user == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Der Benutzer mit dieser E-Mail existiert nicht!" };

                var token = user.PasswordResetToken;
                if (resetPasswordDto.ResetPasswordToken.Trim().Replace(" ", "+") != token)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Token stimmen nicht überein" };
                }
                var hashPassword = userManager.PasswordHasher.HashPassword(user, resetPasswordDto.NewPassword);
                user.PasswordHash = hashPassword;

                await userManager.UpdateAsync(user);
                return new GeneralResponseDto { IsSuccess = true, Message = "Neues Passwort erfolgreich festgelegt!" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new GeneralResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        #endregion Auth

        #region Get

        public async Task<AccountDto> GetById(string accountId, CancellationToken cancellationToken = default)
        {
            var users = await repositoryManager.AccountRepository.GetById(accountId, cancellationToken);
            return users.Adapt<AccountDto>();
        }

        public async Task<IEnumerable<AccountDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var users = await repositoryManager.AccountRepository.GetAll(cancellationToken);
            return users.Adapt<IEnumerable<AccountDto>>();
        }

        #endregion Get

        public async Task<GeneralResponseDto> Create(AccountCreateDto accountDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var userExist = await userManager.FindByEmailAsync(accountDto.Email);
                if (userExist != null)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "User with that email already exists."
                    }!;
                }

                var account = accountDto.Adapt<Account>();
                account.UserName = accountDto.Email;
                var randomPassword = GeneratePassword(7, 1, 1);
                account.Id = Guid.NewGuid().ToString();

                var res = await userManager.CreateAsync(account, randomPassword);

                if (!res.Succeeded)
                {
                    return new GeneralResponseDto()
                    {
                        IsSuccess = false,
                        Message = res.Errors.ToString()
                    };
                }

                var createdUser = await userManager.FindByEmailAsync(account.Email);

                await userManager.AddToRolesAsync(createdUser, accountDto.Roles);
                var code = account.EmailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(account);
                account.EmailConfirmed = true;
                await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

                return new GeneralResponseDto()
                {
                    Data = account.Adapt<AccountDto>(),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task Delete(string accountId, CancellationToken cancellationToken = default)
        {
            var account = await userManager.FindByIdAsync(accountId);
            await userManager.DeleteAsync(account);
        }

        public async Task<GeneralResponseDto> Update(string accountId, AccountUpdateDto account, CancellationToken cancellationToken = default)
        {
            try
            {
                if (accountId != account.Id)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Account Id missmatch."
                    };
                }
                var existingAccount = await userManager.FindByIdAsync(accountId);
                if (existingAccount == null)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Account not found."
                    };
                }
                var emailExist = await userManager.FindByEmailAsync(account.Email);
                if (emailExist != null && existingAccount.Email != account.Email)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error in user information."
                    };
                }

                account.Adapt(existingAccount);
                existingAccount.UserName = existingAccount.Email;

                var response = await userManager.UpdateAsync(existingAccount);

                if (!response.Succeeded)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error"
                    };
                }

                return new GeneralResponseDto
                {
                    IsSuccess = true,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<GeneralResponseDto> ConfirmEmail(ConfirmEmailDto confirmEmailDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(confirmEmailDto.Email);
                if (user == null)
                    return new GeneralResponseDto { IsSuccess = false, Message = "Der Benutzer mit dieser E-Mail existiert nicht!" };

                var token = user.EmailConfirmationToken;
                if (confirmEmailDto.EmailConfirmationToken.Trim().Replace(" ", "+") == token)
                {
                    user.EmailConfirmed = true;

                    await userManager.UpdateAsync(user);
                    return new GeneralResponseDto { IsSuccess = true, Message = "Neues Passwort erfolgreich festgelegt!" };
                }
                else
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Token stimmen nicht überein" };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new GeneralResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        private static string GeneratePassword(int lowercase, int uppercase, int numerics)
        {
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string number = "0123456789";

            Random random = new();

            string generated = "!";
            for (int i = 1; i <= lowercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    lowers[random.Next(lowers.Length - 1)].ToString()
                );

            for (int i = 1; i <= uppercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    uppers[random.Next(uppers.Length - 1)].ToString()
                );

            for (int i = 1; i <= numerics; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    number[random.Next(number.Length - 1)].ToString()
                );

            return generated;
        }
    }
}