using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Domain.Queries;
using SynetecAssessmentApi.Foundation.Core.Interfaces;
using SynetecAssessmentApi.Persistence.Repositories.Interfaces;

namespace SynetecAssessmentApi.Services.Queries
{
    /// <summary>
    /// Handler for Query class GetEmployeesQuery to get list of Employees
    /// </summary>
    public class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, EmployeesDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMap<Employee, EmployeeDto> _map;
        private readonly ILogger<GetEmployeesQueryHandler> _logger;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMap<Employee, EmployeeDto> map, 
            ILogger<GetEmployeesQueryHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _map = map;
            _map = map;
            _logger = logger;
        }

        public async Task<EmployeesDto> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetListAsync(cancellationToken: cancellationToken);
            return new EmployeesDto(_map.Map(employees));
        }
    }
}