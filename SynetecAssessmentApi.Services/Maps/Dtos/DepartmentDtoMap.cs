using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Entities;
using SynetecAssessmentApi.Foundation.Core.Types;

namespace SynetecAssessmentApi.Services.Maps.Dtos
{
    /// <summary>
    /// Department Entity to Dto Mapper
    /// </summary>
    public class DepartmentDtoMap : MapBase<Department, DepartmentDto>
    {
        public DepartmentDtoMap(): base(cfg =>
        {
            cfg.CreateMap<Department, DepartmentDto>();
        })
        {
        }
    }
}