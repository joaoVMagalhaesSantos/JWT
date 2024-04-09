using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Interfaces
{
    public interface IUsuarioRepository
    {
        void Incluir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Usuario usuario);

        Task<Usuario> SelecionarByPk(int id);
        Task<IEnumerable<Usuario>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
