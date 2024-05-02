using Microsoft.AspNetCore.Mvc;
using premio_essencial_back_end.Model;
using premio_essencial_back_end.Services;

namespace premio_essencial_back_end.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParticipanteController : ControllerBase
	{
		private readonly IParticipante _service;

		public ParticipanteController(IParticipante service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult ListarParticipantes()
		{
			List<Participante> participantes = _service.ListarParticipantes();

			return Ok(participantes);
		}

		[HttpGet("{id}")]
		public IActionResult ListarParticipante(int id)
		{
			Participante participante = _service.ListarParticipante(id);

			if (participante == null)
			{
				return NotFound();
			}
			return Ok(participante);
		}

		[HttpPost]
		public IActionResult AdicionarParticipante([FromBody] Participante participanteRecebido)
		{
			Participante participante = _service.AdicionarParticipante(participanteRecebido);

			if (participante == null)
			{
				return BadRequest("Problema ao gravar participante");
			}
			return Ok(participante);
		}


		[HttpGet("consulta/{cpf}")]
		public IActionResult ConferirCpf(string cpf)
		{
			Participante participante = _service.ConferirCpf(cpf);

			if (participante == null)
			{
				return Ok("Não existe esse cpf cadastrado");
			}
			return Ok("Cpf já cadastrado");
		}
	}
}