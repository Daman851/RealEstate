using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace DataLibrary.DatabaseAccess
{
    public static class SQLAccess
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionName = "RealEstateDB")
        {


            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString; 
        }
        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public static List<T> LoadData<T>(string sql)
        {
            using(IDbConnection conn=new SqlConnection(GetConnectionString()))
            {
                return conn.Query<T>(sql).ToList();
            }

        }
        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static int SaveData<T>(string sql,T data)
        {
            
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                try
                {                
                    return conn.Execute(sql,data);
                }
                catch
                {
                    return 0;
                }
            }

        }
        /// <summary>
        /// Deletes the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">The SQL.</param>
        /// <returns></returns>
        public static int DeleteData<T>(string sql)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                return conn.Execute(sql);
            }

        }
    }
}
