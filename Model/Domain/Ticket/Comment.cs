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
        public int Id
        {
            get => _id;
        }
        
        private readonly int _authorId;
        public int AuthorId
        {
            get => _authorId;
        }

        private readonly DateTime _creationDate;
        public DateTime CreationDate
        {
            get => _creationDate;
        }

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
        
        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */

        public Comment(int id, int authorId, string content)
        {
            _id = id;
            _authorId = authorId;
            _creationDate = DateTime.Now;
            _content = content;
        }
    }
}