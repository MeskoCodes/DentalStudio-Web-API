using Domain.Repositories.Billing;
using Domain.Repositories.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Common
{
    public interface IRepositoryManager
    {
        IAccountRepository AccountRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IPatientRepository PatientRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        ITreatmentRepository TreatmentRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }

}
