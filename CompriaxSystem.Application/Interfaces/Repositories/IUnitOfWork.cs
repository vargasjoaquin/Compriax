using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ISaleRepository Sales { get; }
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        IBrandRepository Brands { get; }
        ISupplierRepository Suppliers { get; }
        IPurchaseRepository Purchases { get; }
        IEmployeeRepository Employees { get; }
        IStoreRepository Store { get; }
        IUnitOfMeasureRepository Units { get; }
        IRoleRepository Roles { get; }
        IPromotionRepository Promotions { get; }
        ICashShiftRepository CashShifts { get; }
        ICashRegisterRepository CashRegisters { get; }

        Task<IEnumerable<TaxCondition>> GetTaxConditionsAsync();
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<IEnumerable<CivilStatus>> GetCivilStatusesAsync();
        Task<IEnumerable<Position>> GetPositionsAsync();
        Task<IEnumerable<DocumentType>> GetDocumentTypesAsync();
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();

        Task<bool> CompleteAsync();

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
