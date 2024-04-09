using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.API.Models
{
    public class Login
    {
        [Required(ErrorMessage = "O email é obrigatorio")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
