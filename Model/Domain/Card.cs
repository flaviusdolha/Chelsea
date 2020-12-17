using System.Collections.Generic;

namespace Chelsea.Model.Domain
{
    public class Card
    {
        /*
        * ==========================================
        * PROPERTIES
        * ==========================================
        */
        
        private readonly int _id;
        public int Id
        {
            get => _id;
        }

        private string _name;
        public string Name
        {
            get => _name;
        }

        private List<int> _ticketsIds;
        public List<int> TicketsIds
        {
            get => _ticketsIds;
        }
        
        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */

        public Card(int id, string name)
        {
            _id = id;
            _name = name;
            _ticketsIds = new List<int>();
        }
        
        /*
        * ==========================================
        * METHODS
        * ==========================================
        */

        /// <summary>
        /// Adds a ticket to the list of tickets for this project.
        /// </summary>
        /// <param name="ticketId">An integer number representing the Id of the ticket to be added to the card.</param>
        public void AddTicket(int ticketId)
        {
            _ticketsIds.Add(ticketId);
        }

        /// <summary>
        /// Removes a ticket from the list of tickets for this card.
        /// </summary>
        /// <param name="ticketId">An integer number representing the Id of the ticket to be removed from the card.</param>
        public void RemoveCard(int ticketId)
        {
            _ticketsIds.Remove(ticketId);
        }
    }
}