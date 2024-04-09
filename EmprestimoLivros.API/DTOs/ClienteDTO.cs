using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.API.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [StringLength(14)]
        [Unicode(false)]
        public string CliCpf { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string CliNome { get; set; }

        [StringLength(200)]
        [Unicode(false)]
        public string CliEndereco { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string CliCidade { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string CliBairro { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string CliNumero { get; set; }

        [StringLength(14)]
        [Unicode(false)]
        public string CliTelefoneCelular { get; set; }

        [StringLength(13)]
        [Unicode(false)]
        public string CliTelefoneFixo { get; set; }

        [StringLength(14)]
        [Unicode(false)]
        public int CliInativo { get; set; }

        

    }
}
