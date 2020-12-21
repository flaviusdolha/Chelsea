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
        
        public Ticket(int id, int authorId, string title)
        {
            _id = id;
            _authorId = authorId;
            _title = title;
            _description = "";
            _creationDate = DateTime.Now;
            _priority = Priority.None;
            _status = Status.NotAssigned;
            _labelColour = Colour.NoColour;
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
        /// Removes a member from the list of members that are responsible for this particular ticket.
        /// </summary>
        /// <param name="memberId">An integer number representing the Id of the member to be removed from the ticket.</param>
        public void RemoveMember(int memberId)
        {
            _membersIds.Remove(memberId);
        }

        /// <summary>
        /// Adds a comment to the list of comments of this particular ticket.
        /// </summary>
        /// <param name="commentId">An integer number representing the Id of the comment to be added to the ticket.</param>
        public void AddComment(int commentId)
        {
            _commentsIds.Add(commentId);
        }

        /// <summary>
        /// Removes a comment from the list of comments of this particular ticket.
        /// </summary>
        /// <param name="commentId">An integer number representing the Id of the comment to be removed from the ticket.</param>
        public void RemoveComment(int commentId)
        {
            _commentsIds.Remove(commentId);
        }
    }
}