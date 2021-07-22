using FluentValidation;
using SynetecAssessmentApi.Domain.Queries;

namespace SynetecAssessmentApi.Services.Validators
{
    /// <summary>
    /// Validates the Rule for Query class CalculateBonusQuery
    /// </summary>
    public class CalculateBonusQueryValidator : AbstractValidator<CalculateBonusQuery>
    {
        public CalculateBonusQueryValidator()
        {
            RuleFor(bonus => bonus.SelectedEmployeeId).NotEmpty().NotNull().WithMessage("Bad Request, No Employee Id Specified");
        }
    }
}