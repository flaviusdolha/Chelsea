using Chelsea.Model.Repository;

namespace Chelsea.Model.Service
{
    public class TicketService
    {
        private ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
    }
}