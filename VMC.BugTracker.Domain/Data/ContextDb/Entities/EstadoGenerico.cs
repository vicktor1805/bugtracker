namespace VMC.BugTracker.Domain
{
    public class EstadoGenerico
    {
        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public string? Color { get; set; }
        public bool EsActivo { get; set; }
    }
}