using AutoPractice12.Common;
using System.Collections.Generic;

namespace AutoPractice12.Database
{
    public static class DbQueries
    {
        public static List<EmployeeDto> Employees
            => new EmployeeDAL(ConfigurationProvider.GetCurrent()).GetList();
    }
}
