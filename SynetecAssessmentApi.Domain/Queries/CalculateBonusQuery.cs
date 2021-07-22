using System.ComponentModel.DataAnnotations;
using SynetecAssessmentApi.Domain.QueryResults;
using SynetecAssessmentApi.Foundation.Core.Types;

namespace SynetecAssessmentApi.Domain.Queries
{
    public class CalculateBonusQuery : QueryBase<BonusPoolCalculatorResultDto>
    {
        public int TotalBonusPoolAmount { get; set; }
        public int SelectedEmployeeId { get; set; }

        public CalculateBonusQuery()
        {
            
        }
    }
}