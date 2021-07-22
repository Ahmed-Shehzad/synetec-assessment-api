using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Foundation.Core.Types;

namespace SynetecAssessmentApi.Services.Maps.Dtos
{
    /// <summary>
    /// Employee Entity to Dto Mapper
    /// </summary>
    public class EmployeeDtoMap : MapBase<Employee, EmployeeDto>
    {
        public EmployeeDtoMap(): base(cfg =>
        {
            cfg.CreateMap<Employee, EmployeeDto>();
            cfg.CreateMap<Department, DepartmentDto>();
        })
        {
        }
    }
}