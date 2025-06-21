namespace AT.Data.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int PacoteTuristicoId { get; set; }
        public PacotesTuristicos? PacoteTuristico { get; set; }
        public DateTime Datainicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
