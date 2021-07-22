using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Queries;
using SynetecAssessmentApi.Domain.QueryResults;
using SynetecAssessmentApi.Foundation.Core.Interfaces;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;
using SynetecAssessmentApi.Services.Queries.Rewards;

namespace SynetecAssessmentApi.Services.Queries
{
    /// <summary>
    /// Handler for Query class CalculateBonusQuery
    /// Returns BonusPoolCalculatorResultDto
    /// </summary>
    public class CalculateBonusQueryHandler : IQueryHandler<CalculateBonusQuery, BonusPoolCalculatorResultDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMap<Employee, EmployeeDto> _map;
        private readonly IBonusCalculator _bonusCalculator;
        private readonly ILogger<CalculateBonusQueryHandler> _logger;

        public CalculateBonusQueryHandler(IEmployeeRepository employeeRepository, IMap<Domain.Entities.Employee, EmployeeDto> map, 
            ILogger<CalculateBonusQueryHandler> logger, IBonusCalculator bonusCalculator)
        {
            _employeeRepository = employeeRepository;
            _map = map;
            _map = map;
            _logger = logger;
            _bonusCalculator = bonusCalculator;
        }

        public async Task<BonusPoolCalculatorResultDto> Handle(CalculateBonusQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.SelectedEmployeeId, cancellationToken: cancellationToken);
            if (employee == null)
                return null;

            var employees = await _employeeRepository.GetListAsync(cancellationToken: cancellationToken);

            //get the total salary budget for the company
            var totalSalary = employees.Sum(item => item.Salary);
            
            var bonusAllocation = _bonusCalculator.CalculateBonus(totalSalary, request.TotalBonusPoolAmount, employee.Salary);
            
            var employeeDto = _map.Map(employee);

            return new BonusPoolCalculatorResultDto(bonusAllocation, employeeDto);
        }
    }
}