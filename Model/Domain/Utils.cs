using System;
using System.Data.SqlClient;

namespace Chelsea.Model.Domain
{
    public class Utils
    {
        /// <summary>
        /// Gets a random positive integer number.
        /// </summary>
        /// <returns>A positive integer number.</returns>
        public static int GetRandomInt()
        {
            var random = new Random();
            var number = random.Next();
            return number;
        }

        /// <summary>
        /// Gets the connection string for SQL Database needed to connect to the database of the application.
        /// </summary>
        /// <returns>A string containing the connection string.</returns>
        public static string GetSqlConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.ConnectionString =
                "Server=tcp:chelsea.database.windows.net,1433;Initial Catalog=Chelsea Project;Persist Security Info=False;User ID=chelsea_administrator;Password=zisrub-1qyjka-coWdot;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return builder.ConnectionString;
        }
    }
}