using System.Collections.Generic;
using Chelsea.Model.Domain.Ticket;
using Chelsea.Model.Repository;

namespace Chelsea.Model.Service
{
    public class TicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// Creates a default Ticket and adds it to the Repository.
        ///
        /// A default Ticket has only:
        /// <list type="bullet">
        /// <item>
        /// <term>Title</term>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="authorId">An integer representing the Id of the author of the Ticket.</param>
        /// <param name="title">A string representing the title of the Ticket.</param>
        public void AddTicket(int authorId, string title, int cardId)
        {
            var id = _ticketRepository.GetNextId();
            var ticket = new Ticket(id, authorId, title, cardId);

            _ticketRepository.Create(ticket);
        }

        /// <summary>
        /// Gets all Tickets from the Repository.
        /// </summary>
        /// <returns>A list of Tickets.</returns>
        public List<Ticket> GetAllTickets() => _ticketRepository.GetAll();

        /// <summary>
        /// Gets one Ticket with a specified Id.
        /// </summary>
        /// <param name="ticketId">An integer representing the Id of the Ticket to be retrieved.</param>
        /// <returns>A Ticket representing the Ticket that was requested.</returns>
        public Ticket GetTicketWithId(int ticketId) => _ticketRepository.FindById(ticketId);

        /// <summary>
        /// Modifies the Title of a Ticket.
        /// </summary>
        /// <param name="ticketId">Id of Ticket to be modified.</param>
        /// <param name="title">String of Title to be modified in.</param>
        public void ModifyTitle(int ticketId, string title)
        {
            var ticket = _ticketRepository.FindById(ticketId);
            ticket.Title = title;
            _ticketRepository.Update(ticket);
        }

        /// <summary>
        /// Modifies the Description of a Ticket.
        /// </summary>
        /// <param name="ticketId">Id of Ticket to be modified.</param>
        /// <param name="description">String of Description to be modified in.</param>
        public void ModifyDescription(int ticketId, string description)
        {
            var ticket = _ticketRepository.FindById(ticketId);
            ticket.Description = description;
            _ticketRepository.Update(ticket);
        }

        /// <summary>
        /// Modifies the Priority of a Ticket.
        /// </summary>
        /// <param name="ticketId">Id of Ticket to be modified.</param>
        /// <param name="priority">Priority to be modified in.</param>
        public void ModifyPriority(int ticketId, Priority priority)
        {
            var ticket = _ticketRepository.FindById(ticketId);
            ticket.Priority = priority;
            _ticketRepository.Update(ticket);
        }

        /// <summary>
        /// Modifies the Status of a Ticket.
        /// </summary>
        /// <param name="ticketId">Id of Ticket to be modified.</param>
        /// <param name="status">Status to be modified in.</param>
        public void ModifyStatus(int ticketId, Status status)
        {
            var ticket = _ticketRepository.FindById(ticketId);
            ticket.Status = status;
            _ticketRepository.Update(ticket);
        }

        /// <summary>
        /// Modifies the LabelColour of a Ticket.
        /// </summary>
        /// <param name="ticketId">Id of Ticket to be modified.</param>
        /// <param name="labelColour">String of LabelColour to be modified in.</param>
        public void ModifyLabelColour(int ticketId, string labelColour)
        {
            var ticket = _ticketRepository.FindById(ticketId);
            ticket.LabelColour = labelColour;
            _ticketRepository.Update(ticket);
        }

        /// <summary>
        /// Moves a Ticket to another card.
        /// </summary>
        /// <param name="ticketId">Id of Ticket to be moved.</param>
        /// <param name="cardId">Id of the card to be moved in.</param>
        public void ModifyToAnotherCard(int ticketId, int cardId)
        {
            var ticket = _ticketRepository.FindById(ticketId);
            ticket.CardId = cardId;
            _ticketRepository.Update(ticket);
        }

        /// <summary>
        /// Removes a Ticket from the Repository.
        /// </summary>
        /// <param name="ticketId">An integer representing the Id of the Ticket to be removed.</param>
        public void RemoveTicket(int ticketId) => _ticketRepository.Delete(ticketId);
    }
}