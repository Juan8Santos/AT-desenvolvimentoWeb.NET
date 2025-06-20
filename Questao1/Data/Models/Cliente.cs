using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AT.Data.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Erro! o campo precisa ser preenchido.")]
        [MinLength(3, ErrorMessage = "Erro! o nome precisa ter mais de 3 letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Erro! o campo precisa ser preenchido.")]
        [EmailAddress(ErrorMessage = "Erro! o email não segue os padrões exigidos.")]
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public DateTime? Deleted { get; set; }
    }
}
