namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IPasswordHasher
    {
        /// <summary>
        /// Genera un hash seguro a partir de una contraseña en texto plano.
        /// </summary>
        /// <param name="password">Contraseña a encriptar.</param>
        /// <returns>La cadena del hash generado.</returns>
        string Hash(string password);

        /// <summary>
        /// Verifica si una contraseña en texto plano coincide con un hash almacenado.
        /// </summary>
        /// <param name="password">Contraseña ingresada por el usuario.</param>
        /// <param name="hash">Hash contra el cual comparar.</param>
        /// <returns>Verdadero si la contraseña es correcta, falso en caso contrario.</returns>
        bool Verify(string password, string hash);
    }
}
