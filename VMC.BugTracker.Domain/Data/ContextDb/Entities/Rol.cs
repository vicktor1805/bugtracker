using System;
using System.Collections.Generic;
using System.Text;
using VMC.BugTracker.Domain.Data.ContextDb;

namespace VMC.BugTracker.Domain
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public bool EsAdministrador { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<RolProyecto> RolProyectos { get; set; }
    }
}