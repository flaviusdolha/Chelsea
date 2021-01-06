using System;
using System.Collections.Generic;
using Chelsea.Model.Domain.Ticket;
using Chelsea.Model.Repository;

namespace Chelsea.Model.Service
{
    public class CommentService
    {
        private readonly IRepository<Comment> _commentRepository;

        public CommentService(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        /// <summary>
        /// Creates a Comment and adds it to the Repository.
        /// </summary>
        public void AddComment(Dictionary<string, dynamic> options)
        {
            var id = _commentRepository.GetNextId();
            if (id == 0) throw new Exception("Internal server error when trying to add a Comment.");
            var comment = new Comment(id, Int32.Parse(options["authorId"].ToString()), options["content"].ToString(), Int32.Parse(options["ticketId"].ToString()));
            _commentRepository.Create(comment);
        }

        /// <summary>
        /// Gets all Comments from the Repository.
        /// </summary>
        /// <returns>A list of Comments.</returns>
        public List<Comment> GetAllComments() => _commentRepository.GetAll();
        
        /// <summary>
        /// Gets all Comments from the Repository that are contained in a specified ticket.
        /// </summary>
        /// <param name="ticketId">An integer representing the Id of the ticket to be retrieved from.</param>
        /// <returns>A list of Comments.</returns>
        public List<Comment> GetAllComments(int ticketId) => _commentRepository.GetAllOnParent(ticketId);

        /// <summary>
        /// Gets one Comment with a specified Id.
        /// </summary>
        /// <param name="commentId">An integer representing the Id of the Comment to be retrieved.</param>
        /// <returns>A Comment representing the Comment that was requested.</returns>
        public Comment GetCommentWithId(int commentId) => _commentRepository.FindById(commentId);

        /// <summary>
        /// Modifies one Comment
        /// </summary>
        /// <param name="comment">Comment to be modified.</param>
        public void ModifyComment(Comment comment) => _commentRepository.Update(comment);

        /// <summary>
        /// Removes a Comment from the Repository.
        /// </summary>
        /// <param name="commendId">An integer representing the Id of the Comment to be removed.</param>
        public void RemoveComment(int commentId) => _commentRepository.Delete(commentId);
    }
}