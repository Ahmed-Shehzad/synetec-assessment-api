using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SynetecAssessmentApi.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }
        
        /// <summary>
        /// Queries to corresponding Handler
        /// </summary>
        /// <param name="query"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await _mediator.Send(query);
        }

        /// <summary>
        /// Returns 404 When Not found
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected ActionResult<T> NotNull<T>(T data)
        {
            if (data == null) return BadRequest();
            return Ok(data);
        }
    }
}