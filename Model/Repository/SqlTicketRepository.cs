using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Chelsea.Model.Domain.Ticket;

namespace Chelsea.Model.Repository
{
    public class SqlTicketRepository : IRepository<Ticket>
    {
        private readonly SqlConnection _connection;

        public SqlTicketRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        
        public void Create(Ticket ticket)
        {
            var sql = $"INSERT INTO [dbo].[Ticket] VALUES ({ticket.AuthorId}, " +
                      $"'{ticket.Title}', '{ticket.Description}', '{ticket.CreationDate}', " +
                      $"{(int) ticket.Priority}, {(int) ticket.Status}, " +
                      $"'{ticket.LabelColour}', {ticket.CardId});";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public List<Ticket> GetAll()
        {
            var sql = "SELECT * FROM [dbo].[Ticket];";
            return _ReadWithSqlString(sql);
        }

        public List<Ticket> GetAllOnParent(int cardId)
        {
            var sql = $"SELECT * FROM [dbo].[Ticket] WHERE CardId = {cardId};";
            return _ReadWithSqlString(sql);
        }

        public Ticket FindById(int ticketId)
        {
            var sql = $"SELECT TOP 1 * FROM [dbo].[Ticket] WHERE Id = {ticketId};";
            return _ReadWithSqlString(sql).First();
        }

        public void Update(Ticket ticket)
        {
            var sql = $"UPDATE [dbo].[Ticket] " +
                      $"SET Title = '{ticket.Title}', Description = '{ticket.Description}', " +
                      $"Priority = {(int) ticket.Priority}, Status = {(int) ticket.Status}, " +
                      $"LabelColour = '{ticket.LabelColour}', CardId = {ticket.CardId} " +
                      $"WHERE Id = {ticket.Id};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public void Delete(int ticketId)
        {
            var sql = $"DELETE FROM [dbo].[Ticket] WHERE Id = {ticketId};";
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                sqlCommand.ExecuteNonQuery();
            }
            
            _connection.Close();
        }

        public int GetNextId()
        {
            var sql = "SELECT IDENT_CURRENT('Ticket') AS TicketId;";
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

        private List<Ticket> _ReadWithSqlString(string sql)
        {
            var list = new List<Ticket>();
            _connection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(sql, _connection))
            {
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            var ticket = new Ticket(sqlDataReader.GetInt32(0), sqlDataReader.GetInt32(1), sqlDataReader.GetString(2), sqlDataReader.GetDateTime(4), sqlDataReader.GetInt32(8));
                            ticket.Description = sqlDataReader.GetString(3);
                            ticket.Priority = (Priority)sqlDataReader.GetByte(5);
                            ticket.Status = (Status)sqlDataReader.GetByte(6);
                            ticket.LabelColour = sqlDataReader.GetString(7);
                            list.Add(ticket);
                        }
                    }
                }
            }
            
            _connection.Close();
            return list;
        }
    }
}