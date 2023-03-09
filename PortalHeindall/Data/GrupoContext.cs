using Microsoft.EntityFrameworkCore;
using PortalHeindall.Models;

namespace PortalHeindall.Data
{
    public class GrupoContext : DbContext
    {
        public GrupoContext(DbContextOptions<GrupoContext> options)
        : base(options) => Database.EnsureCreated();

        public DbSet<Grupo> Grupos { get; set; }

		public DbSet<Integrador> Integradores { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

		public DbSet<IntegradordoUsuario> IntegradoresdoUsuario { get; set; }

	}
}
