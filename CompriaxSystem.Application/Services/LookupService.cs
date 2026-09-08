using CompriaxSystem.Application.Interfaces.Repositories;
using CompriaxSystem.Application.Interfaces.Services;
using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Services
{
    public class LookupService(IUnitOfWork unitOfWork) : ILookupService
    {
        /// <summary>
        /// Obtiene el listado de condiciones fiscales (IVA) registradas.
        /// </summary>
        /// <returns>Una colección de condiciones fiscales.</returns>
        public async Task<IEnumerable<TaxCondition>> GetTaxConditionsAsync() => await unitOfWork.GetTaxConditionsAsync();

        /// <summary>
        /// Recupera el catálogo de géneros para registros de personas.
        /// </summary>
        /// <returns>Una colección de géneros.</returns>
        public async Task<IEnumerable<Gender>> GetGendersAsync() => await unitOfWork.GetGendersAsync();

        /// <summary>
        /// Obtiene las opciones de estado civil disponibles.
        /// </summary>
        /// <returns>Una colección de estados civiles.</returns>
        public async Task<IEnumerable<CivilStatus>> GetCivilStatusesAsync() => await unitOfWork.GetCivilStatusesAsync();

        /// <summary>
        /// Recupera el listado de posiciones o cargos laborales.
        /// </summary>
        /// <returns>Una colección de cargos.</returns>
        public async Task<IEnumerable<Position>> GetPositionsAsync() => await unitOfWork.GetPositionsAsync();

        /// <summary>
        /// Obtiene los tipos de documentos de identidad soportados por el sistema.
        /// </summary>
        /// <returns>Una colección de tipos de documentos.</returns>
        public async Task<IEnumerable<DocumentType>> GetDocumentTypesAsync() => await unitOfWork.GetDocumentTypesAsync();

        /// <summary>
        /// Recupera los métodos de pago habilitados para las transacciones.
        /// </summary>
        /// <returns>Una colección de métodos de pago.</returns>
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync() => await unitOfWork.GetPaymentMethodsAsync();
    }
}