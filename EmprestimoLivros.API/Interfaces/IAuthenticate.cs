using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> UserExist(string email);
        public string GenerateToken(int id, string email);
        public Task<Usuario> GetUserByEmail(string email);

    }
}
