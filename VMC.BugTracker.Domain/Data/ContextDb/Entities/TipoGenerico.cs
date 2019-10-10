namespace VMC.BugTracker.Domain
{
    public class TipoGenerico
    {
        public int TipoGenericoId { get; set; }
        public string Nombre { get; set; }
        public string? Color { get; set; }
        public bool EsActivo { get; set; }
    }
}