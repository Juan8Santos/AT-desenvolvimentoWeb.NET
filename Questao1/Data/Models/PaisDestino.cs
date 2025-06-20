namespace AT.Data.Models
{
    public class PaisDestino
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<CidadeDestino> CidadeDestino { get; set; } = new List<CidadeDestino>();
    }
}
