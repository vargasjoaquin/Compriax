using CompriaxSystem.Domain.Entities;

namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Busca un producto por su código de barras.
        /// </summary>
        /// <param name="barcode">Código de barras del producto.</param>
        /// <returns>La entidad del producto encontrado.</returns>
        Task<Product?> GetByBarcodeAsync(string barcode);

        /// <summary>
        /// Obtiene todos los productos con sus detalles adicionales.
        /// </summary>
        /// <returns>Colección de productos con detalles.</returns>
        Task<IEnumerable<Product>> GetAllWithDetailsAsync();

        /// <summary>
        /// Obtiene un producto por su id.
        /// </summary>
        /// <param name="id">ID del producto.</param>
        /// <returns>Entidad del producto.</returns>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// Agrega un nuevo producto al catálogo.
        /// </summary>
        /// <param name="product">Entidad del producto.</param>
        Task AddAsync(Product product);

        /// <summary>
        /// Registra un movimiento de stock asociado a un producto.
        /// </summary>
        /// <param name="movement">Entidad del movimiento de stock.</param>
        Task AddMovementAsync(StockMovement movement);

        /// <summary>
        /// Actualiza la información de un producto.
        /// </summary>
        /// <param name="product">Entidad con datos nuevos.</param>
        void Update(Product product);

        /// <summary>
        /// Guarda los cambios en el repositorio de productos.
        /// </summary>
        /// <returns>Resultado de la persistencia.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Recupera los productos que han sido eliminados del catálogo.
        /// </summary>
        /// <returns>Colección de productos borrados.</returns>
        Task<IEnumerable<Product>> GetAllDeletedAsync();

        /// <summary>
        /// Busca un producto eliminado por su ID.
        /// </summary>
        /// <param name="id">ID del producto borrado.</param>
        /// <returns>La entidad del producto.</returns>
        Task<Product?> GetDeletedByIdAsync(int id);
    }
}
