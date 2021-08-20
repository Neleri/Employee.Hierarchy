using System;
using Xunit;

namespace Employee.Hierarchy.Test
{
    public class Employee_Service_Should
    {
        private Employee _employeeService;

        public Employee_Service_Should()
        {
            _employeeService = new Employee(@"C:\Users\TSOMI\Desktop\Exercise\Test1\Employee.Hierarchy\TestFiles\test.csv");
        }

        [Fact]
        public void Return_Equal_Salary_Budget()
        {
            var result = _employeeService.SalaryBudget("Employee2");

            Assert.Equal(1000, result);
        }

    }
}
