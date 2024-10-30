using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Contract.Account
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; } // ID zaposlenog
        public string FirstName { get; set; } = string.Empty; // Ime
        public string? LastName { get; set; } // Prezime
        public string Specialization { get; set; } = string.Empty; // Specijalizacija
        public string? MobileNumber { get; set; } // Broj telefona
        public string? Email { get; set; } // Email
        public List<string> Roles { get; } = new List<string>(); // Uloge zaposlenog
    }

    public class EmployeeCreateDto
    {
        public string FirstName { get; set; } = string.Empty; // Ime
        public string? LastName { get; set; } // Prezime
        public string Specialization { get; set; } = string.Empty; // Specijalizacija
        public string? MobileNumber { get; set; } // Broj telefona
        public string? Email { get; set; } // Email
        public List<string> Roles { get; } = new List<string>(); // Uloge
    }

    public class EmployeeUpdateDto
    {
        public int EmployeeId { get; set; } // ID zaposlenog
        public string FirstName { get; set; } = string.Empty; // Ime
        public string? LastName { get; set; } // Prezime
        public string Specialization { get; set; } = string.Empty; // Specijalizacija
        public string? MobileNumber { get; set; } // Broj telefona
        public string? Email { get; set; } // Email
        public List<string> Roles { get; } = new List<string>(); // Uloge
    }
}
