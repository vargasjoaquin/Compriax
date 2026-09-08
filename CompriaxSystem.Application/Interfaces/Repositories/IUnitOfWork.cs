using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        // Las propiedades representan los repositorios accesibles a través de UnitOfWork.
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

        /// <summary>
        /// Obtiene la lista de condiciones fiscales.
        /// </summary>
        /// <returns>Colección de condiciones frente al IVA.</returns>
        Task<IEnumerable<TaxCondition>> GetTaxConditionsAsync();

        /// <summary>
        /// Obtiene el catálogo de géneros.
        /// </summary>
        /// <returns>Colección de géneros.</returns>
        Task<IEnumerable<Gender>> GetGendersAsync();

        /// <summary>
        /// Obtiene el listado de estados civiles.
        /// </summary>
        /// <returns>Colección de estados civiles.</returns>
        Task<IEnumerable<CivilStatus>> GetCivilStatusesAsync();

        /// <summary>
        /// Obtiene las posiciones o cargos laborales.
        /// </summary>
        /// <returns>Colección de cargos.</returns>
        Task<IEnumerable<Position>> GetPositionsAsync();

        /// <summary>
        /// Obtiene los tipos de comprobantes.
        /// </summary>
        /// <returns>Colección de tipos de comprobantes.</returns>
        Task<IEnumerable<DocumentType>> GetDocumentTypesAsync();

        /// <summary>
        /// Obtiene los métodos de pago.
        /// </summary>
        /// <returns>Colección de métodos de pago.</returns>
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();

        /// <summary>
        /// Confirma y persiste todos los cambios realizados en el contexto actual.
        /// </summary>
        /// <returns>Verdadero si la operación fue exitosa.</returns>
        Task<bool> CompleteAsync();

        /// <summary>
        /// Inicia una nueva transacción explícita en la base de datos.
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Confirma los cambios realizados durante la transacción activa.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Revierte los cambios realizados durante la transacción activa en caso de error.
        /// </summary>
        Task RollbackAsync();
    }
}
