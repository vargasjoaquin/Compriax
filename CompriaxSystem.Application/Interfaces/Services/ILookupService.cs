using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Services
{
    public interface ILookupService
    {
        /// <summary>
        /// Recupera las condiciones de IVA.
        /// </summary>
        /// <returns>Colección de condiciones fiscales.</returns>
        Task<IEnumerable<TaxCondition>> GetTaxConditionsAsync();

        /// <summary>
        /// Recupera el catálogo de géneros.
        /// </summary>
        /// <returns>Colección de géneros.</returns>
        Task<IEnumerable<Gender>> GetGendersAsync();

        /// <summary>
        /// Recupera las opciones de estado civil.
        /// </summary>
        /// <returns>Colección de estados civiles.</returns>
        Task<IEnumerable<CivilStatus>> GetCivilStatusesAsync();

        /// <summary>
        /// Recupera los cargos o posiciones laborales.
        /// </summary>
        /// <returns>Colección de puestos.</returns>
        Task<IEnumerable<Position>> GetPositionsAsync();

        /// <summary>
        /// Recupera los tipos de documentos de identidad.
        /// </summary>
        /// <returns>Colección de tipos de documento.</returns>
        Task<IEnumerable<DocumentType>> GetDocumentTypesAsync();

        /// <summary>
        /// Recupera los medios de pago configurados.
        /// </summary>
        /// <returns>Colección de medios de pago.</returns>
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
    }
}
