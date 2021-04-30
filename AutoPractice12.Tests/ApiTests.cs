using System;
using System.Collections.Generic;
using System.Globalization;
using AutoPractice12.Database;
using AutoPractice12.Services.Endpoints;
using AutoPractice12.Services.Extentions;
using AutoPractice12.Services.Models;
using AutoPractice12.Tests.Resources;
using NUnit.Framework;

namespace AutoPractice12.Tests
{
    [TestFixture]
    public class ApiTests : BaseFixture
    {
        [Test]
        [Category("API")]
        [Category("Employees")]
        [Category("Smoke")]
        public void CheckEmployeesCountFromApiAndDatabase()
        {
            var response = Client.
                Execute(EmployeeEndpoint.GetAllEmployees()).
                EnsureSuccess().
                As<Response<List<EmployeeEntity>>>();

            Assert.That(response.Data.Count, Is.EqualTo(DbQueries.Employees.Count));
        }

        [Test]
        [Category("API")]
        [Category("Employee")]
        [TestCaseSource(typeof(TestCasesSource), "GetEmployees")]
        public void CheckEmployeeReturned(EmployeeDto employee)
        {
            var response = Client.
                Execute(EmployeeEndpoint.GetEmployee(employee.Id)).
                EnsureSuccess().
                As<Response<EmployeeEntity>>();

            Assert.Multiple(() =>
            {
                Assert.That(response.Data.Id,
                    Is.EqualTo(employee.Id.ToString()),
                    $"[Id] Actual is '{response.Data.Id}', but expected is '{employee.Id.ToString()}'");
                Assert.That(response.Data.EmployeeName,
                    Is.EqualTo(employee.Name),
                    $"[Name] Actual is '{response.Data.EmployeeName}', but expected is '{employee.Name}'");
                Assert.That(response.Data.EmployeeSalary,
                    Is.EqualTo(employee.Salary.ToString(CultureInfo.InvariantCulture)),
                    $"[Salary] Actual is '{response.Data.EmployeeSalary}', but expected is '{employee.Salary.ToString(CultureInfo.InvariantCulture)}'");
                Assert.That(response.Data.EmployeeAge,
                    Is.EqualTo(employee.Age.ToString()),
                    $"[Age] Actual is '{response.Data.EmployeeAge}', but expected is '{employee.Age.ToString()}'");
            });
        }
    }
}
