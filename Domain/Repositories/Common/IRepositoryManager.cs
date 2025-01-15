using Domain.Repositories.Billing;

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
