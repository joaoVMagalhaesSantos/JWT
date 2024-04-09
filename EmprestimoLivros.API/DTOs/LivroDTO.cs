using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.API.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string LivroNome { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string LivroAutor { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string LivroEditora { get; set; }

        public DateTime? LivroAnoPublicacao { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string LivroEdicao { get; set; }

    }
}
