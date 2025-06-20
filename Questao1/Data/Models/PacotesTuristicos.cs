namespace AT.Data.Models
{
    public class PacotesTuristicos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal PrecoDiaria { get; set; }

        public List<Reserva> Reserva { get; set; } = new List<Reserva>();
        public List<Destino> Destinos { get; set; } = new List<Destino>();
    }
}

