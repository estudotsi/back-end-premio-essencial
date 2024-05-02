using premio_essencial_back_end.Model;

namespace premio_essencial_back_end.Services
{
	public interface IParticipante
	{
		List<Participante> ListarParticipantes();
		Participante ListarParticipante(int Id);
		Participante AdicionarParticipante(Participante participante);
		Participante ConferirCpf(string Cpf);
	}
}
