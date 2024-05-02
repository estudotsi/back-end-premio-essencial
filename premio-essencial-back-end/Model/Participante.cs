using Microsoft.AspNetCore.Hosting.Server;

namespace premio_essencial_back_end.Model
{
	public class Participante
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string CPF { get; set; }
		public string? ArquivoMatriculaTitular { get; set; }
		public string Tipo { get; set; }
	}
}
