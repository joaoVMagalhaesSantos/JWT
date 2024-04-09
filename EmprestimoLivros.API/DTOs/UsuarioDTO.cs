using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.API.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string Nome { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string Email { get; set; }

        
        [StringLength(200)]
        [Unicode(false)]
        [NotMapped]
        public string Password { get; set; }
    }
}
