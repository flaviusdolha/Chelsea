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
                if (Title.Length <= 100) _title = value;
                else throw new ArgumentOutOfRangeException("Ticket title must have maximum 100 characters.");
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => _description = value;
        }
        
        private readonly DateTime _creationDate;
        public DateTime CreationDate
        {
            get => CreationDate;
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

        private string _labelColor;
        public string LabelColor
        {
            get => _labelColor;
            set
            {
                if (Colour.IsValidColor(value)) _labelColor = value;
                else throw new ArgumentException("Specified label colour is not valid.");
            }
        }

        private List<int> _membersIds;
        public List<int> MembersIds
        {
            get => _membersIds;
        }

        private List<int> _commentsIds;
        public List<int> CommentsIds
        {
            get => _commentsIds;
        }

        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */
        
        public Ticket(int authorId, string title)
        {
            _id = Utils.GetRandomInt();
            _authorId = authorId;
            _title = title;
            _description = "";
            _creationDate = DateTime.Now;
            _priority = Priority.None;
            _status = Status.NotAssigned;
            _labelColor = Colour.NoColour;
            _membersIds = new List<int>();
            _commentsIds = new List<int>();
        }
        
        /*
        * ==========================================
        * METHODS
        * ==========================================
        */
        
        /// <summary>
        /// Adds a member to the list of members that are responsible for this particular ticket.
        /// </summary>
        /// <param name="memberId">An integer number representing the Id of the member to be added to the ticket.</param>
        public void AddMember(int memberId)
        {
            _membersIds.Add(memberId);
        }

        /// <summary>
        /// Adds a comment to the list of comments of this particular ticket.
        /// </summary>
        /// <param name="commentId">An integer number representing the Id of the comment to be added to the ticket.</param>
        public void AddComment(int commentId)
        {
            _commentsIds.Add(commentId);
        }
    }
}