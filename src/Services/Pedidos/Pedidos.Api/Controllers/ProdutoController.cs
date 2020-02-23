using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Application.Produtos.Commands.CreateProduto;
using Pedidos.Application.Produtos.Commands.UpdateProduto;
using Pedidos.Application.Produtos.Queries;
using Pedidos.Application.Produtos.Queries.GetDetalhesProduto;
using Pedidos.Application.Produtos.Queries.GetListaProdutos;
using System;
using System.Threading.Tasks;


namespace Pedidos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _mediator.Send(new GetListaProdutosQuery());

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> ObterDetalhesProduto(int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var produto = await _mediator.Send(new GetDetalhesProdutoQuery(id));

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CriarProduto([FromBody] CreateProdutoRequest request)
        {
            var commandResult = await _mediator.Send(new CreateProdutoCommand(request));

            if (!commandResult)
                return BadRequest("Erro ao cadastrar o produto.");

            return Created(string.Empty, commandResult);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarProduto([FromBody] UpdateProdutoRequest request)
        {
            var commandResult = await _mediator.Send(new UpdateProdutoCommand(request));

            if (!commandResult)
                return BadRequest();

            return Ok();
        }

    }
}