using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Services
{
    public class LookupService(IUnitOfWork unitOfWork) : ILookupService
    {
        public async Task<IEnumerable<TaxCondition>> GetTaxConditionsAsync() => await unitOfWork.GetTaxConditionsAsync();
        public async Task<IEnumerable<Gender>> GetGendersAsync() => await unitOfWork.GetGendersAsync();
        public async Task<IEnumerable<CivilStatus>> GetCivilStatusesAsync() => await unitOfWork.GetCivilStatusesAsync();
        public async Task<IEnumerable<Position>> GetPositionsAsync() => await unitOfWork.GetPositionsAsync();
        public async Task<IEnumerable<DocumentType>> GetDocumentTypesAsync() => await unitOfWork.GetDocumentTypesAsync();
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync() => await unitOfWork.GetPaymentMethodsAsync();
    }
}