namespace SynetecAssessmentApi.Services.Queries.Rewards
{
    /// <summary>
    /// Class to Calculate Bonus implemented by Service IBonusCalculator
    /// </summary>
    public class BonusCalculator : IBonusCalculator
    {
        public int CalculateBonus(int totalSalary, int totalBonusPoolAmount, int employeeSalary)
        {   
            //calculate the bonus allocation for the employee
            var bonusPercentage = (decimal)employeeSalary / totalSalary;
            var bonusAllocation = (int)(bonusPercentage * totalBonusPoolAmount);
            return bonusAllocation;
        }
    }
}