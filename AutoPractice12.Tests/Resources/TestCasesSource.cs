using System.Collections.Generic;
using AutoPractice12.Database;

namespace AutoPractice12.Tests.Resources
{
    public static class TestCasesSource
    {
        public static IEnumerable<EmployeeDto> GetEmployees()
        {
            foreach (var employee in DbQueries.Employees)
            {
                yield return employee;
            }
        }
    }
}
