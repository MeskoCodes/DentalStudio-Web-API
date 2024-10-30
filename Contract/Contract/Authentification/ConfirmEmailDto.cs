using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Authentification
{
    public class ConfirmEmailDto
    {
        public string Email { get; set; }
        public string EmailConfirmationToken { get; set; }
    }
}
