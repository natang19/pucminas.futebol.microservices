using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Commands;
using pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Queries;
using pucminas.futebol.jogador.api._3_Domain.DTOs;

namespace pucminas.futebol.jogador.api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("jogadores")]
    public class JogadorController : ControllerBase
    {
        private readonly ILogger<JogadorController> _logger;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public JogadorController(ILogger<JogadorController> logger, ISender mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(typeof(IEnumerable<JogadorResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<JogadorResponseDTO>>> Get()
        {
            var querieResult = await _mediator.Send(new ObterJogadoresQuerie());

            if (!querieResult.Any())
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<JogadorResponseDTO>>(querieResult));
        }

        [HttpGet("{id}")]
        [EnableQuery]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JogadorResponseDTO>> GetById([FromRoute] string id)
        {
            var jogador = await _mediator.Send(new ObterJogadorPorIdQuerie(id));

            if (jogador is null)
            {
                return NotFound("Jogador n�o encontrado!");
            }

            return Ok(_mapper.Map<JogadorResponseDTO>(jogador));
        }

        [HttpPost]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] JogadorDTO jogadorDto)
        {
            var commandResult = await _mediator.Send(new CadastrarJogadorCommand(jogadorDto.Nome, jogadorDto.Sobrenome, jogadorDto.DataNascimento, jogadorDto.Pais, jogadorDto.IdTime));

            var jogadorResponseDto = _mapper.Map<JogadorResponseDTO>(commandResult);

            return CreatedAtAction(nameof(GetById), new { jogadorResponseDto.Id }, jogadorResponseDto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JogadorResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] JogadorUpdateDTO jogadorDto)
        {
            JogadorResponseDTO jogadorResponseDto;

            if (string.IsNullOrEmpty(jogadorDto.Id))
            {
                var criacaoCommandResult = await _mediator.Send(new CadastrarJogadorCommand(jogadorDto.Nome, jogadorDto.Sobrenome, jogadorDto.DataNascimento, jogadorDto.Pais, jogadorDto.IdTime));

                jogadorResponseDto = _mapper.Map<JogadorResponseDTO>(criacaoCommandResult);

                return CreatedAtAction(nameof(GetById), new { jogadorResponseDto.Id }, jogadorResponseDto);
            }

            var atualizacaoCommandResult = await _mediator.Send(new AtualizarJogadorCommand(jogadorDto));
            jogadorResponseDto = _mapper.Map<JogadorResponseDTO>(atualizacaoCommandResult);

            return Ok(jogadorResponseDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _mediator.Send(new ExcluirJogadorCommand(id));

            return NoContent();
        }
    }
}