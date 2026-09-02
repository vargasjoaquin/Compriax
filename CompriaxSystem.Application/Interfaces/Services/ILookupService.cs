using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ILookupService
    {
        Task<IEnumerable<TaxCondition>> GetTaxConditionsAsync();
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<IEnumerable<CivilStatus>> GetCivilStatusesAsync();
        Task<IEnumerable<Position>> GetPositionsAsync();
        Task<IEnumerable<DocumentType>> GetDocumentTypesAsync();
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
    }
}
