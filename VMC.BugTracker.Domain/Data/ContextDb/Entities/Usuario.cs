using System;
using System.Collections;
using System.Collections.Generic;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public int RolId { get; set; }
        public string Correo { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public bool CorreoVerificado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public EstadoGenerico Estado { get; set; }
        public Rol Rol { get; set; }

        public ICollection<Incidencia> IncidenciasRegistradas { get; set; }
        public ICollection<Incidencia> IncidenciasAsignadas { get; set; }


    }
}
