using System.ComponentModel.DataAnnotations;

namespace APE.Application.ViewModels.Cliente
{
    public class CadastrarClienteViewModel
    {
        [Required]
        public int IdGenero { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Cpf { get; set; }
        [Required]
        public ContatoCadastroViewModel Contato { get; set; }

    }
}
