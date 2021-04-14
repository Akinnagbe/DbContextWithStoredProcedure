using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DynamicStoredProcedure
{
    public static class Extension
    {
        /// <summary>
        /// ef core
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storedProcedure"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static DataTable FromStoredProcedureToDataTableEfCore(this DbContext context,string storedProcedure, params DbParameter[] sqlParameters)
        {
            DataTable dataTable = new DataTable();
            // using (var db = new DbContext())
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                DbConnection connection = context.Database.GetDbConnection();
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

                command.CommandText = storedProcedure;
                command.CommandType = CommandType.StoredProcedure;

                foreach (var dbParam in sqlParameters)
                {
                    command.Parameters.Add(dbParam);
                }

                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(dataTable);
                }


                //command.CommandText = "[dbo].[spFraudPortalRule171]";
                //command.CommandType = CommandType.StoredProcedure;
                //DbParameter ruleIdParam = command.CreateParameter();
                //ruleIdParam.ParameterName = "@RuleID";//@ReferenceId
                //ruleIdParam.Value = 171;
                //command.Parameters.Add(ruleIdParam);

                //DbParameter refIdParam = command.CreateParameter();
                //refIdParam.ParameterName = "@ReferenceId";//
                //refIdParam.Value = 4545;
                //command.Parameters.Add(refIdParam);

                //using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                //{
                //    adapter.SelectCommand = command;
                //    adapter.Fill(dataTable);
                //}


            }

            return dataTable;
        }

        /// <summary>
        /// EF .Net Framework
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storedProcedure"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static DataTable FromStoredProcedureToDataTableEf(this DbContext context, string storedProcedure, params DbParameter[] sqlParameters)
        {
            DataTable dataTable = new DataTable();
            //using (var command = context.Database.Connection.CreateCommand())
            //{
            //    DbConnection connection = context.Database.Connection;
            //    DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);

            //    command.CommandText = storedProcedure;
            //    command.CommandType = CommandType.StoredProcedure;

            //    foreach (var dbParam in sqlParameters)
            //    {
            //        command.Parameters.Add(dbParam);
            //    }

            //    using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
            //    {
            //        adapter.SelectCommand = command;
            //        adapter.Fill(dataTable);
            //    }

            //}

            return dataTable;
        }


        public static Dictionary<string,string> ToDictionary(this DataTable dataTable)
        {
            var dictionary = new Dictionary<string, string>();

           
            foreach (DataColumn column in dataTable.Columns)
            {               
                dictionary.Add(column.ColumnName, dataTable.Rows[0][column].ToString()); 
            }

            return dictionary;
        }
    
    }
}
