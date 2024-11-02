using Domain.Repositories;
using Domain.Repositories.Billing;
using Domain.Repositories.Common;
using Domain.Repositories.Scheduling;
using Persistence.Repositories.Billing;
using Persistence.Repositories.Scheduling;

namespace Persistence.Repositories
{
    public class RepositoryManager(DataContext dbContext) : IRepositoryManager
    {
        private readonly Lazy<IAccountRepository> _lazyAccountRepository = new(() => new AccountRepository(dbContext));
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork = new(() => new UnitOfWork(dbContext));
        private readonly Lazy<IEmployeeRepository> _lazyEmployeeRepository = new(() => new EmployeeRepository(dbContext));
        private readonly Lazy<IPatientRepository> _lazyPatientRepository = new(() => new PatientRepository(dbContext));
        private readonly Lazy<ITreatmentRepository> _lazyTreatmentRepository = new(() => new TreatmentRepository(dbContext));
        
        // Repozitori za Billing
        private readonly Lazy<IInvoiceRepository> _lazyInvoiceRepository = new(() => new InvoiceRepository(dbContext));
        private readonly Lazy<IPaymentRepository> _lazyPaymentRepository = new(() => new PaymentRepository(dbContext));
        
        // Repozitori za Scheduling
        private readonly Lazy<IAppointmentRepository> _lazyAppointmentRepository = new(() => new AppointmentRepository(dbContext));

        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IEmployeeRepository EmployeeRepository => _lazyEmployeeRepository.Value;
        public IPatientRepository Patientrepository => _lazyPatientRepository.Value;

        public IPatientRepository PatientRepository => throw new NotImplementedException();

        public ITreatmentRepository TreatmentRepository => _lazyTreatmentRepository.Value;

        // Billing repozitoriji
        public IInvoiceRepository InvoiceRepository => _lazyInvoiceRepository.Value;
        public IPaymentRepository PaymentRepository => _lazyPaymentRepository.Value;

        // Scheduling repozitoriji
        public IAppointmentRepository AppointmentRepository => _lazyAppointmentRepository.Value;
    }
}
