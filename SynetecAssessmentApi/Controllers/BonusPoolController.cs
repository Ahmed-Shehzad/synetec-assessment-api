using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using SynetecAssessmentApi.Controllers.Base;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Queries;
using SynetecAssessmentApi.Domain.QueryResults;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : ApiControllerBase
    {
        public BonusPoolController(IMediator mediator) : base(mediator)
        {
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(EmployeesDto),200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<EmployeesDto>> GetAll()
        {
            return NotNull(await QueryAsync(new GetEmployeesQuery()));
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(BonusPoolCalculatorResultDto),200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<BonusPoolCalculatorResultDto>> CalculateBonus([FromBody] CalculateBonusQuery request)
        {
            return NotNull(await QueryAsync(request));
        }
    }
}
