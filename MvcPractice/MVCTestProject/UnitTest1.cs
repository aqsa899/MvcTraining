using MvcPractice.Controllers;
using Microsoft.AspNetCore.Mvc;
using MvcPractice.Models;
using System.Collections.Generic;
using Xunit;
namespace MVCTestProject {
    public class EmployeeControllerTests
    {
        [Fact] // Marks this as a unit test
        public void GetEmployees_Returns_JsonResult_With_Employees()
        {
            // Arrange
            var controller = new EmployeeController();

            // Act
            var result = controller.GetEmployees() as JsonResult;

            // Assert
            Assert.NotNull(result);
            var employees = Assert.IsType<List<Employee>>(result.Value);
            Assert.Equal(3, employees.Count); // Ensure 3 employees are returned
            Assert.Equal("Alice", employees[0].Name); // Ensure first employee is Alice
        }
    }
}
