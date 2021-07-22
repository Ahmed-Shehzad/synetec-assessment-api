namespace SynetecAssessmentApi.Services.Queries.Rewards
{
    /// <summary>
    /// Service to Calculate Bonus
    /// </summary>
    public interface IBonusCalculator
    {
        public int CalculateBonus(int totalSalary, int bonusPoolAmount, int employeeSalary);
    }
}