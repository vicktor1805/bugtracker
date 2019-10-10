using System;
using System.Collections.Generic;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioResponsableId { get; set; }
        public int UsuarioRegistroId { get; set; }
        public int TipoProyectoId { get; set; }
        public DateTime FechaRegistro { get; set; }

        public EstadoGenerico Estado { get; set; }
        public Usuario UsuarioResponsable { get; set; }
        public Usuario UsuarioRegistro { get; set; }
        public TipoGenerico TipoProyecto { get; set; }

        public ICollection<RolProyecto> RolProyectos { get; set; }
        public ICollection<Incidencia> Incidencias { get; set; }
    }
}
