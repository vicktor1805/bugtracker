using System;
using System.Collections;
using System.Collections.Generic;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class Incidencia
    {
        public int IncidenciaId { get; set; }
        public int NumeroIncidencia { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaCierre { get; set; }
        public int UsuarioRegistroId { get; set; }
        public int ProyectoId { get; set; }
        public int? UsuarioAsignadoId { get; set; }
        public int EstadoId { get; set; }
        public Usuario UsuarioRegistro { get; set; }
        public Usuario? UsuarioAsignado { get; set; }
        public Proyecto Proyecto { get; set; }
        public EstadoGenerico Estado { get; set; }


        public ICollection<IncidenciaCambio> IncidenciaCambios { get; set; }
        public ICollection<IncidenciaAdjunto> IncidenciaAdjuntos { get; set; }
        public ICollection<IncidenciaComentario> IncidenciaComentarios { get; set; }
    }
}
