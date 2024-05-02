using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using premio_essencial_back_end.Model;

namespace premio_essencial_back_end.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Participante> Participantes { get; set; }

	}
}
