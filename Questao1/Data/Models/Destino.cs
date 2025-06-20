namespace AT.Data.Models
{
    public class Destino
    {
        public int PacoteTuristicoId { get; set; }
        public PacotesTuristicos PacoteTuristico { get; set; }

        public int CidadeDestinoId { get; set; }
        public CidadeDestino CidadeDestino { get; set; }

        public int OrdemVisita { get; set; }
    }
}
