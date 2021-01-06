using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Chelsea.Model.Domain;

namespace Chelsea.Model.Repository
{
    public class SqlProjectRepository : IRepository<Project>
    {
        private readonly SqlConnection _connection;

        public SqlProjectRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(Project project)
        {
            var sql = $"INSERT INTO [dbo].[Project] VALUES (" +
                      $"{project.OwnerId}, '{project.Name}');";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public List<Project> GetAll()
        {
            var sql = "SELECT * FROM [dbo].[Project];";
            return _ReadWithSqlString(sql);
        }

        public List<Project> GetAllOnParent(int ownerId)
        {
            var sql = $"SELECT * FROM [dbo].[Project] WHERE OwnerId = {ownerId};";
            return _ReadWithSqlString(sql);
        }

        public Project FindById(int projectId)
        {
            var sql = $"SELECT TOP 1 * FROM [dbo].[Project] WHERE Id = {projectId};";
            if (_ReadWithSqlString(sql).Count == 0) return null;
            return _ReadWithSqlString(sql).First();
        }

        public void Update(Project project)
        {
            var sql = $"UPDATE [dbo].[Project] " +
                      $"SET Name = '{project.Name}' WHERE Id = {project.Id};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public void Delete(int projectId)
        {
            var sql = $"DELETE FROM [dbo].[Project] WHERE Id = {projectId};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public int GetNextId()
        {
            var sql = "SELECT IDENT_CURRENT('Project') AS ProjectId;";
            _connection.Open();
            var id = 0;
            
            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        id = Decimal.ToInt32(sqlDataReader.GetDecimal(0) + 1);
                    }
                }
            }
            
            _connection.Close();
            return id;
        }
        
        private List<Project> _ReadWithSqlString(string sql)
        {
            var list = new List<Project>();
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            var project = new Project(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1), sqlDataReader.GetString(2));
                            list.Add(project);
                        }
                    }
                }
            }
            
            _connection.Close();
            return list;
        }
    }
}