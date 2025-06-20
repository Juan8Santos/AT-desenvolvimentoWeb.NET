using System.ComponentModel.DataAnnotations;

namespace AT.Data.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Erro! o campo precisa ser preenchido.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Erro! O nome da cidade precisa estar entre 3 e 30 letras")]
        public string Nome { get; set; }
        public int PaisDestinoId { get; set; }

        [Required(ErrorMessage = "Erro! o campo precisa ser preenchido.")]
        public PaisDestino PaisDestino { get; set; }

        public List<Destino> Destinos { get; set; } = new List<Destino>();
    }
}