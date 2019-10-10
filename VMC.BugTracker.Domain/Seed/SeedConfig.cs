using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VMC.BugTracker.Domain.Data.ContextDb;

namespace VMC.BugTracker.Domain.Seed
{
    public static class SeedConfig
    {

        public static async void AddBaseData(DbContextOptions<BugTrackerContext> contextOptions)
        {

            using (BugTrackerContext context = new BugTrackerContext(contextOptions))
            {
                var adminRole = await context.Rol.FirstOrDefaultAsync(x => x.Nombre == "Administrador");

                if (adminRole == null)
                {
                    adminRole = new Rol
                    {
                        Nombre = "Administador",
                        EsAdministrador = true,
                        
                    };
                };
            }

        }

    }
}
