using System;
using System.Collections.Generic;
using Chelsea.Model.Domain;
using Chelsea.Model.Repository;

namespace Chelsea.Model.Service
{
    public class CardService
    {
        private readonly IRepository<Card> _cardRepository;

        public CardService(IRepository<Card> cardRepository)
        {
            _cardRepository = cardRepository;
        }

        /// <summary>
        /// Creates a Card and adds it to the Repository.
        /// </summary>
        public void AddCard(Dictionary<string, dynamic> options)
        {
            var id = _cardRepository.GetNextId();
            if (id == 0) throw new Exception("Internal server error when trying to add a Card.");
            var card = new Card(id, options["name"].ToString(), Int32.Parse(options["projectId"].ToString()));
            _cardRepository.Create(card);
        }

        /// <summary>
        /// Gets all Cards from the Repository.
        /// </summary>
        /// <returns>A list of Cards.</returns>
        public List<Card> GetAllCards() => _cardRepository.GetAll();
        
        /// <summary>
        /// Gets all Cards from the Repository that are contained in a specified ticket.
        /// </summary>
        /// <param name="projectId">An integer representing the Id of the project to be retrieved from.</param>
        /// <returns>A list of Cards.</returns>
        public List<Card> GetAllCards(int projectId) => _cardRepository.GetAllOnParent(projectId);

        /// <summary>
        /// Gets one Card with a specified Id.
        /// </summary>
        /// <param name="cardId">An integer representing the Id of the Card to be retrieved.</param>
        /// <returns>A Card representing the Card that was requested.</returns>
        public Card GetCardWithId(int cardId) => _cardRepository.FindById(cardId);

        /// <summary>
        /// Modifies one Card
        /// </summary>
        /// <param name="card">Card to be modified.</param>
        public void ModifyCard(Card card) => _cardRepository.Update(card);

        /// <summary>
        /// Removes a Card from the Repository.
        /// </summary>
        /// <param name="cardId">An integer representing the Id of the Card to be removed.</param>
        public void RemoveCard(int cardId) => _cardRepository.Delete(cardId);
    }
}