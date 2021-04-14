using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;

namespace DynamicStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunStoreProcedure();
        }

        static void RunStoreProcedure()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (var db = new SampleDbContext())
                {
                    dataTable = db.FromStoredProcedureToDataTable("spFraudPortalRule171", new[] { new SqlParameter("RuleID", 171), new SqlParameter("ReferenceId", 4545) });
                }

                var dictionary = dataTable.ToDictionary();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
