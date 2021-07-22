using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Controllers;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Domain.Queries;
using SynetecAssessmentApi.Domain.QueryResults;
using SynetecAssessmentApi.UnitTests.Mocks;
using Xunit;

namespace SynetecAssessmentApi.UnitTests
{
    public class BonusPoolControllerTest : MockServiceProvider
    {
        private readonly BonusPoolController _controller;
        public BonusPoolControllerTest()
        {
            var mediator = ServiceProvider.GetRequiredService<IMediator>();
            _controller = new BonusPoolController(mediator);
        }
        /// Unit Testing Controller Actions
        /// Test Will Pass if response will not be null and returns the status code for OK of 200
        [Fact]
        public async Task BonusPoolController_GetAll_Employees_Should_Return_True_When_Valid()
        {
            var employees = await _controller.GetAll();
            var value = (employees.Result as OkObjectResult)!.Value;
            var statusCode = (employees.Result as OkObjectResult)!.StatusCode;

            Assert.True(statusCode == 200);
            Assert.True(value is EmployeesDto);
        }
        /// Unit Testing Controller Actions        
        /// Test Will Pass when bonus allocated to employee and returns the status code for OK of 200
        [Fact]
        public async Task BonusPoolController_CalculateBonus_Should_Return_True_When_Valid()
        {
            var bonus = new CalculateBonusQuery
            {
                SelectedEmployeeId = 3,
                TotalBonusPoolAmount = 1234560
            };
            var res = await _controller.CalculateBonus(bonus);
            var value = (res.Result as OkObjectResult)!.Value;
            Assert.True(value is BonusPoolCalculatorResultDto);
        }
    }
}