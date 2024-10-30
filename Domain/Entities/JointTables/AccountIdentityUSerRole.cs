using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Domain.Entities;

public class AccountIdentityUserRole : IdentityUserRole<string>
{
    public virtual Account User { get; set; }
    public virtual AccountRole Role { get; set; }

    public override string ToString() => Role.Name;
}