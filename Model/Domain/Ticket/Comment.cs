using System;

namespace Chelsea.Model.Domain.Ticket
{
    public class Comment
    {
        /*
        * ==========================================
        * PROPERTIES
        * ==========================================
        */
        
        private readonly int _id;
        public int Id => _id;

        private readonly int _authorId;
        public int AuthorId => _authorId;

        private readonly DateTime _creationDate;
        public DateTime CreationDate => _creationDate;

        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                if (Content.Length <= 128) _content = value;
                else throw new ArgumentOutOfRangeException("Comment's content must have maximum 256 characters.");
            }
        }

        private readonly int _ticketId;

        public int TicketId => _ticketId;

        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */

        public Comment(int id, int authorId, string content, int ticketId)
        {
            _id = id;
            _authorId = authorId;
            _creationDate = DateTime.Now;
            _content = content;
            _ticketId = ticketId;
        }

        // Use this constructor to create objects that are retrieved from the Database.
        public Comment(int id, int authorId, DateTime creationDate, string content, int ticketId)
        {
            _id = id;
            _authorId = authorId;
            _creationDate = creationDate;
            _content = content;
            _ticketId = ticketId;
        }
    }
}