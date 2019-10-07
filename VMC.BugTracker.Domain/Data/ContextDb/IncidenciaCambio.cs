using System;
using System.Collections.Generic;
using System.Text;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class IncidenciaCambio
    {
        public int IncidenciaCambioId { get; set; }
        public int IncidenciaId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioId { get; set; }
        public Incidencia Incidencia { get; set; }
        public Usuario Usuario { get; set; }
        public EstadoGenerico Estado { get; set; }

    }
}
