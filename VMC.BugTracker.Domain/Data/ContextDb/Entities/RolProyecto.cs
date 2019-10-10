using System;
using System.Collections.Generic;
using System.Text;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class RolProyecto
    {
        public int RolId { get; set; }
        public int ProyectoId { get; set; }
        public Rol Rol { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}
