using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;


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
    }
}