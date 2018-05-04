namespace Portafolio.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Portafolio : DbContext
    {
        public Portafolio()
            : base("name=PortafolioConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ADMIN_PORTAFOLIO");
        }
    }
}