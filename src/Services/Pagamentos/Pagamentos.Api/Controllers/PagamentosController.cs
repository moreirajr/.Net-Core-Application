using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.Application.Pagamentos.Commands;
using System;
using System.Threading.Tasks;

namespace Pagamentos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagamentosController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RealizarPagamento([FromBody] CreatePagamentoRequest request)
        {
            var commandResult = await _mediator.Send(new CreatePagamentoCommand(request));

            if (!commandResult)
                return BadRequest("Erro ao realizar pagamento.");

            return Created(string.Empty, commandResult);
        }
    }
}