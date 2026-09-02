using Microsoft.EntityFrameworkCore;
using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Infrastructure.Persistence;

namespace CompriaxSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Products = new ProductRepository(_context);
            Sales = new SaleRepository(_context);
            Customers = new CustomerRepository(_context);
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
            Brands = new BrandRepository(_context);
            Suppliers = new SupplierRepository(_context);
            Purchases = new PurchaseRepository(_context);
            Employees = new EmployeeRepository(_context);
            Store = new StoreRepository(_context);
            Units = new UnitOfMeasureRepository(_context);
            Roles = new RoleRepository(_context);
            Promotions = new PromotionRepository(_context);
            CashShifts = new CashShiftRepository(_context);
            CashRegisters = new CashRegisterRepository(_context);
        }

        public IProductRepository Products { get; }
        public ISaleRepository Sales { get; }
        public ICustomerRepository Customers { get; }
        public IUserRepository Users { get; }
        public ICategoryRepository Categories { get; }
        public IBrandRepository Brands { get; }
        public ISupplierRepository Suppliers { get; }
        public IPurchaseRepository Purchases { get; }
        public IEmployeeRepository Employees { get; }
        public IStoreRepository Store { get; }
        public IUnitOfMeasureRepository Units { get; }
        public IRoleRepository Roles { get; }
        public IPromotionRepository Promotions { get; }
        public ICashShiftRepository CashShifts { get; }
        public ICashRegisterRepository CashRegisters { get; }

        public async Task<IEnumerable<TaxCondition>> GetTaxConditionsAsync() => await _context.TaxConditions.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<Gender>> GetGendersAsync() => await _context.Genders.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<CivilStatus>> GetCivilStatusesAsync() => await _context.CivilStatuses.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<Position>> GetPositionsAsync() => await _context.Positions.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<DocumentType>> GetDocumentTypesAsync() => await _context.DocumentTypes.AsNoTracking().ToListAsync();
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync() => await _context.PaymentMethods.Where(p => p.IsActive).AsNoTracking().ToListAsync();

        public async Task<bool> CompleteAsync() => await _context.SaveChangesAsync() > 0;

        public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
        public async Task CommitAsync() => await _context.Database.CommitTransactionAsync();
        public async Task RollbackAsync() => await _context.Database.RollbackTransactionAsync();

        public void Dispose() => _context.Dispose();
    }
}