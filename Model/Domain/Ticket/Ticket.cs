using System;
using System.Collections.Generic;

namespace Chelsea.Model.Domain.Ticket
{
    public class Ticket
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

        private readonly int _authorId;
        public int AuthorId
        {
            get => _authorId;
        }
        
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (Title.Length <= 128) _title = value;
                else throw new ArgumentOutOfRangeException("Ticket's title must have maximum 128 characters.");
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (Description.Length <= 4000) _description = value;
                else throw new ArgumentOutOfRangeException("Ticket's description must have maximum 4000 characters.");
            }
        }
        
        private readonly DateTime _creationDate;
        public DateTime CreationDate
        {
            get => _creationDate;
        }

        private Priority _priority;
        public Priority Priority
        {
            get => _priority;
            set => _priority = value;
        }

        private Status _status;
        public Status Status
        {
            get => _status;
            set => _status = value;
        }

        private string _labelColour;
        public string LabelColour
        {
            get => _labelColour;
            set
            {
                if (Colour.IsValidColour(value)) _labelColour = value;
                else throw new ArgumentException("Specified label colour is not valid.");
            }
        }

        private int _cardId;

        public int CardId
        {
            get => _cardId;
            set => _cardId = value;
        }

        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */
        
        public Ticket(int id, int authorId, string title, int cardId)
        {
            _id = id;
            _authorId = authorId;
            _title = title;
            _description = "";
            _creationDate = DateTime.Now;
            _priority = Priority.None;
            _status = Status.NotAssigned;
            _labelColour = Colour.NoColour;
            _cardId = cardId;
        }
        
        // Use this constructor to create objects that are retrieve from the Database.
        public Ticket(int id, int authorId, string title, DateTime creationDate, int cardId)
        {
            _id = id;
            _authorId = authorId;
            _title = title;
            _description = "";
            _creationDate = creationDate;
            _priority = Priority.None;
            _status = Status.NotAssigned;
            _labelColour = Colour.NoColour;
            _cardId = cardId;
        }
    }
}