using System.Collections.Generic;

namespace SynetecAssessmentApi.Domain.Dtos
{
    public class EmployeesDto: List<EmployeeDto>
    {
        public EmployeesDto(IEnumerable<EmployeeDto> products)
        {
            AddRange(products);
        }
    }
}