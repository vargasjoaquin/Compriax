namespace CompriaxSystem.Application.Interfaces.Repositories
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }
}
