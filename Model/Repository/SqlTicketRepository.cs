using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Chelsea.Model.Domain;
using Chelsea.Model.Domain.Ticket;

namespace Chelsea.Model.Repository
{
    public class SqlTicketRepository : ITicketRepository
    {
        private readonly SqlConnection _connection;

        public SqlTicketRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        
        public void Create(Ticket ticket)
        {
            throw new System.NotImplementedException();
        }

        public List<Ticket> GetAll()
        {
            var list = new List<Ticket>();
            _connection.Open();
            var sql = "SELECT * FROM [dbo].[Ticket]";

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

        public Ticket FindById(int ticketId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Ticket ticket)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int ticketId)
        {
            throw new System.NotImplementedException();
        }

        public int GetNextId()
        {
            throw new System.NotImplementedException();
        }
    }
}