namespace AT.Data.Models
{
    public class PacotesTuristicos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public int Reservados { get; set; }
        public decimal PrecoDiaria { get; set; }

        public event Action<string>? CapacityReached;
        public List<Reserva> Reserva { get; set; } = new List<Reserva>();
        public List<Destino> Destinos { get; set; } = new List<Destino>();
        public void AdicionarReserva()
        {
            Reservados++;

            if (Reservados >= CapacidadeMaxima)
            {
                CapacityReached?.Invoke($"⚠️ Capacidade atingida para o pacote \"{Titulo}\".");
            }
        }
    }

}

