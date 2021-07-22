using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Services.Queries.Rewards;
using SynetecAssessmentApi.UnitTests.Mocks;
using Xunit;

namespace SynetecAssessmentApi.UnitTests
{
    public class BonusCalculatorTest : MockServiceProvider
    {
        private readonly IBonusCalculator _bonusCalculator;
        public BonusCalculatorTest()
        {
            _bonusCalculator = ServiceProvider.GetRequiredService<IBonusCalculator>();
        }
        
        /// The Calculations are Unit Tested
        [Fact]
        public void BonusCalculator_CalculateBonus_Bonus_Allocated()
        {
            const int totalSalary = 12345600;
            const int bonusPoolAmount = 150000000;
            const int employeeSalary = 45000;
            
            var bonusAllocated = _bonusCalculator.CalculateBonus(totalSalary, bonusPoolAmount, employeeSalary);
            
            Assert.True(bonusAllocated > 1);
        }
    }
}