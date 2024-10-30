namespace Contract.Authentification;

public class AuthenticationDto
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? AccountId { get; set; }
    public string? AccountFirstName { get; set; }
}