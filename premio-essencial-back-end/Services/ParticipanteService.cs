using premio_essencial_back_end.Data;
using premio_essencial_back_end.Model;

namespace premio_essencial_back_end.Services
{
	public class ParticipanteService : IParticipante
	{
		private readonly DataContext _context;

		public ParticipanteService(DataContext context)
		{
			_context = context;
		}

		public List<Participante> ListarParticipantes()
		{
			try
			{
				List<Participante> participantes = _context.Participantes.ToList();

				if (participantes == null)
				{
					return null;
				}

				return participantes;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Participante ListarParticipante(int Id)
		{
			try
			{
				Participante participante = _context.Participantes.FirstOrDefault(p => p.Id == Id);

				if (participante == null)
				{
					return null;
				}
				return participante;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public Participante AdicionarParticipante(Participante participante)
		{
			_context.Participantes.Add(participante);
			_context.SaveChanges();

			return participante;
		}

		public Participante ConferirCpf(string Cpf)
		{
			try
			{
				Participante participante = _context.Participantes.FirstOrDefault(p => p.CPF == Cpf);

				if (participante == null)
				{
					return null;
				}
				return participante;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
