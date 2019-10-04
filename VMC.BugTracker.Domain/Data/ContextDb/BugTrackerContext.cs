using Microsoft.EntityFrameworkCore;

namespace VMC.BugTracker.Domain.Data.ContextDb
{
    public class BugTrackerContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
