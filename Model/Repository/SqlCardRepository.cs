using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Chelsea.Model.Domain;

namespace Chelsea.Model.Repository
{
    public class SqlCardRepository : IRepository<Card>
    {
        private readonly SqlConnection _connection;

        public SqlCardRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Create(Card card)
        {
            var sql = $"INSERT INTO [dbo].[Card] VALUES (" +
                      $"'{card.Name}', {card.ProjectId});";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public List<Card> GetAll()
        {
            var sql = "SELECT * FROM [dbo].[Card];";
            return _ReadWithSqlString(sql);
        }

        public List<Card> GetAllOnParent(int projectId)
        {
            var sql = $"SELECT * FROM [dbo].[Card] WHERE ProjectId = {projectId};";
            return _ReadWithSqlString(sql);
        }

        public Card FindById(int cardId)
        {
            var sql = $"SELECT TOP 1 * FROM [dbo].[Card] WHERE Id = {cardId};";
            if (_ReadWithSqlString(sql).Count == 0) return null;
            return _ReadWithSqlString(sql).First();
        }

        public void Update(Card card)
        {
            var sql = $"UPDATE [dbo].[Card] " +
                      $"SET Name = '{card.Name}' WHERE Id = {card.Id};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public void Delete(int cardId)
        {
            var sql = $"DELETE FROM [dbo].[Card] WHERE Id = {cardId};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public int GetNextId()
        {
            var sql = "SELECT IDENT_CURRENT('Card') AS CardId;";
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
        
        private List<Card> _ReadWithSqlString(string sql)
        {
            var list = new List<Card>();
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            var card = new Card(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetInt32(2));
                            list.Add(card);
                        }
                    }
                }
            }
            
            _connection.Close();
            return list;
        }
    }
}