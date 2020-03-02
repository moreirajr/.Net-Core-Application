using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Pedidos.Commands.CreatePedido;
using System;
using System.Threading.Tasks;

namespace Pedidos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RealizarPedido([FromBody] CreatePedidoRequest request)
        {
            var commandResult = await _mediator.Send(new CreatePedidoCommand(request));

            if (!commandResult)
                return BadRequest("Erro ao realizar pedido.");

            return Created(string.Empty, commandResult);
        }
    }
}