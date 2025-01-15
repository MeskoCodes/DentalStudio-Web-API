using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.JointTables;

public class AccountIdentityUserRole : IdentityUserRole<string>
{
    public virtual Account User { get; set; }
    public virtual AccountRole Role { get; set; }

    public override string ToString() => Role.Name;
}