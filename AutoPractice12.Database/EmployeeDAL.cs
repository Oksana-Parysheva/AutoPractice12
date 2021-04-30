using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoPractice12.Database
{
    public class EmployeeDAL
    {
        private readonly string _connectionString;

        public EmployeeDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AutoPracticeDatabase");
        }

        public List<EmployeeDto> GetList()
        {
            var listCountryModel = new List<EmployeeDto>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from [AutoPractice].[dbo].[Employee]", con)
                    {
                        CommandType = CommandType.Text
                    };
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            listCountryModel.Add(new EmployeeDto
                            {
                                Id = Convert.ToInt32(rdr.GetSqlValue(0).ToString()),
                                Name = rdr.GetSqlValue(1).ToString(),
                                Salary = Convert.ToDecimal(rdr.GetSqlValue(2).ToString()),
                                Age = Convert.ToInt32(rdr.GetSqlValue(3).ToString()),
                                ProfileImage = rdr.GetSqlValue(4).ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"There is a problem with SQL connection or data reading. {ex.Message} {ex.InnerException}");
            }

            return listCountryModel;
        }
    }
}
