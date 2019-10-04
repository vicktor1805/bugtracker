using System;
using System.Collections.Generic;
using System.Text;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class IncidenciaAdjunto
    {
        public int IncidenciaAdjuntoId { get; set; }
        public int IncidenciaId { get; set; }
        public string RutaVirtual { get; set; }
        public string ExtensionArchivo { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Usuario Usuario { get; set; }
        public Incidencia Incidencia { get; set; }
    }
}
