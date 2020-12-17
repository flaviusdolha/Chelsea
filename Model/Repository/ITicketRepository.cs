using System.Collections.Generic;
using Chelsea.Model.Domain.Ticket;

namespace Chelsea.Model.Repository
{
    public interface ITicketRepository
    {
        public void Create(Ticket ticket);
        public List<Ticket> GetAll();
        public Ticket FindById(int ticketId);
        public void Update(Ticket ticket);
        public void Delete(int ticketId);
        public int GetNextId();
    }
}