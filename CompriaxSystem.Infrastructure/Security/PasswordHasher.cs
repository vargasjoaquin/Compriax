using CompriaxSystem.Application.Interfaces.Repositories;

namespace CompriaxSystem.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Genera un hash seguro para una contraseña en texto plano utilizando el algoritmo BCrypt.
        /// </summary>
        /// <param name="password">La contraseña en texto plano que se desea encriptar.</param>
        /// <returns>La cadena del hash generado listo para ser almacenado.</returns>
        public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        /// <summary>
        /// Compara una contraseña en texto plano con un hash almacenado para verificar su validez.
        /// </summary>
        /// <param name="password">La contraseña ingresada por el usuario.</param>
        /// <param name="hash">El hash almacenado previamente en la base de datos.</param>
        /// <returns>Verdadero si la contraseña coincide con el hash; falso en caso contrario.</returns>
        public bool Verify(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
    }
}