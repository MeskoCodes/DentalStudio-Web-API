﻿global using Contract;
global using System.Security.Claims;
using Services.Abstractions.Billing;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }

        IPaymentService PaymentService { get; }

        IEmployeeService EmployeeService { get; }
        IInvoiceService InvoiceService { get; }
        IPatientService PatientService { get; }

        ITreatmentService TreatmentService { get; }
    }
}