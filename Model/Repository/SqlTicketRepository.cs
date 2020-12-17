using System.Collections.Generic;
using Chelsea.Model.Domain.Ticket;

namespace Chelsea.Model.Repository
{
    public class SqlTicketRepository : ITicketRepository
    {
        public void Create(Ticket ticket)
        {
            throw new System.NotImplementedException();
        }

        public List<Ticket> GetAll()
        {
            throw new System.NotImplementedException();
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