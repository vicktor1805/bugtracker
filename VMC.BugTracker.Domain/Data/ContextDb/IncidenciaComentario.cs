﻿using System;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class IncidenciaComentario
    {
        public int IncidenciaComentarioId { get; set; }
        public int IncidenciaId { get; set; }
        public string Comentario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EstadoId { get; set; }

        public Incidencia Incidencia { get; set; }
        public Usuario Usuario { get; set; }
        public EstadoGenerico Estado { get; set; }
    }
}
