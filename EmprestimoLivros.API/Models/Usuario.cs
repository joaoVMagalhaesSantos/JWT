using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.API.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        [StringLength(200)]
        [Unicode(false)]
        [Required]
        public string Nome { get; set; }

        [Column("email")]
        [StringLength(200)]
        [Unicode(false)]
        [Required]
        public string Email { get; set;}

        [Column("passwordHash")]
        [StringLength(200)]
        [Unicode(false)]
        public byte[] PasswordHash { get; set;}

        [Column("passwordSalt")]
        [StringLength(200)]
        [Unicode(false)]
        public byte[] PasswordSalt { get; set; }

        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }


        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt) 
        {
            PasswordHash = passwordHash; 
            PasswordSalt = passwordSalt;
        }

    }
}
