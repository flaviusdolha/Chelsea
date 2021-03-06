using System;
using System.Collections.Generic;
using Chelsea.Model.Domain.Ticket;
using Chelsea.Model.Repository;

namespace Chelsea.Model.Service
{
    public class TicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// Creates a Ticket and adds it to the Repository.
        /// </summary>
        public void AddTicket(Dictionary<string, dynamic> options)
        {
            var id = _ticketRepository.GetNextId();
            if (id == 0) throw new Exception("Internal server error when trying to add a Ticket.");
            var ticket = new Ticket(id, Int32.Parse(options["authorId"].ToString()), options["title"].ToString(), Int32.Parse(options["cardId"].ToString()));
            if (options.ContainsKey("description")) ticket.Description = options["description"].ToString();
            if (options.ContainsKey("priority")) ticket.Priority = (Priority) options["priority"].ToString();
            if (options.ContainsKey("status")) ticket.Status = (Status) options["status"].ToString();
            if (options.ContainsKey("labelColour")) ticket.LabelColour = options["labelColour"].ToString();
            _ticketRepository.Create(ticket);
        }

        /// <summary>
        /// Gets all Tickets from the Repository.
        /// </summary>
        /// <returns>A list of Tickets.</returns>
        public List<Ticket> GetAllTickets() => _ticketRepository.GetAll();
        
        /// <summary>
        /// Gets all Tickets from the Repository that are contained in a specified card.
        /// </summary>
        /// <param name="cardId">An integer representing the Id of the card to be retrieved from.</param>
        /// <returns>A list of Tickets.</returns>
        public List<Ticket> GetAllTickets(int cardId) => _ticketRepository.GetAllOnParent(cardId);

        /// <summary>
        /// Gets one Ticket with a specified Id.
        /// </summary>
        /// <param name="ticketId">An integer representing the Id of the Ticket to be retrieved.</param>
        /// <returns>A Ticket representing the Ticket that was requested.</returns>
        public Ticket GetTicketWithId(int ticketId) => _ticketRepository.FindById(ticketId);

        /// <summary>
        /// Modifies one Ticket with specified options.
        /// </summary>
        /// <param name="options">Options of the ticket to be modified.</param>
        public void ModifyTicket(Dictionary<string, dynamic> options, Ticket ticket)
        {
            if (options.ContainsKey("title")) ticket.Title = options["title"].ToString();
            if (options.ContainsKey("description")) ticket.Description = options["description"].ToString();
            if (options.ContainsKey("priority")) ticket.Priority = (Priority) options["priority"].ToString();
            if (options.ContainsKey("status")) ticket.Status = (Status) options["status"].ToString();
            if (options.ContainsKey("labelColour")) ticket.LabelColour = options["labelColour"].ToString();
            if (options.ContainsKey("cardId")) ticket.CardId = (int) options["cardId"].ToString();
            _ticketRepository.Update(ticket);
        }

        /// <summary>
        /// Removes a Ticket from the Repository.
        /// </summary>
        /// <param name="ticketId">An integer representing the Id of the Ticket to be removed.</param>
        public void RemoveTicket(int ticketId) => _ticketRepository.Delete(ticketId);
    }
}