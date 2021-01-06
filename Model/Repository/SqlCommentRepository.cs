using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Chelsea.Model.Domain.Ticket;

namespace Chelsea.Model.Repository
{
    public class SqlCommentRepository : IRepository<Comment>
    {
        private readonly SqlConnection _connection;

        public SqlCommentRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(Comment comment)
        {
            var sql = $"INSERT INTO [dbo].[Comment] VALUES (" +
                      $"{comment.AuthorId}, '{comment.CreationDate}', " +
                      $"'{comment.Content}', {comment.TicketId});";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public List<Comment> GetAll()
        {
            var sql = "SELECT * FROM [dbo].[Comment];";
            return _ReadWithSqlString(sql);
        }

        public List<Comment> GetAllOnParent(int ticketId)
        {
            var sql = $"SELECT * FROM [dbo].[Comment] WHERE TicketId = {ticketId};";
            return _ReadWithSqlString(sql);
        }

        public Comment FindById(int commentId)
        {
            var sql = $"SELECT TOP 1 * FROM [dbo].[Comment] WHERE Id = {commentId};";
            if (_ReadWithSqlString(sql).Count == 0) return null;
            return _ReadWithSqlString(sql).First();
        }

        public void Update(Comment comment)
        {
            var sql = $"UPDATE [dbo].[Comment] " +
                      $"SET Content = '{comment.Content}' WHERE Id = {comment.Id};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public void Delete(int commentID)
        {
            var sql = $"DELETE FROM [dbo].[Comment] WHERE Id = {commentID};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public int GetNextId()
        {
            var sql = "SELECT IDENT_CURRENT('Comment') AS CommentId;";
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
        
        private List<Comment> _ReadWithSqlString(string sql)
        {
            var list = new List<Comment>();
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            var comment = new Comment(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1), sqlDataReader.GetDateTime(2), sqlDataReader.GetString(3), sqlDataReader.GetInt32(4));
                            list.Add(comment);
                        }
                    }
                }
            }
            
            _connection.Close();
            return list;
        }
    }
}