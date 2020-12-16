using System;

namespace Chelsea.Model.Domain.Ticket
{
    public class Comment
    {
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
            set => _content = value;
        }
    }
}