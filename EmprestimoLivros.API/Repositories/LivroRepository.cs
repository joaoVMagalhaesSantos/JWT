using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.API.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _context;

        public LivroRepository(BibliotecaContext context)
        {
            _context = context; 
        }

        public void Alterar(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
        }

        public void Excluir(Livro livro)
        {
            _context.Livros.Remove(livro);
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await _context.Livros.ToListAsync();
        }

        public void Incluir(Livro livro)
        {
            _context.Livros.Add(livro);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Livro> SelecionarByPK(int id)
        {
            return await _context.Livros.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
