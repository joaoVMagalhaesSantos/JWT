using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Interfaces
{
    public interface ILivroRepository
    {
        void Incluir(Livro livro);
        void Alterar(Livro livro);
        void Excluir(Livro livro);

        Task<Livro> SelecionarByPK(int id);
        Task<IEnumerable<Livro>> GetAll();
        Task<bool> SaveAllAsync();

    }
}
