using System.Collections.Generic;

namespace Chelsea.Model.Domain
{
    public class Project
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

        private readonly int _ownerId;
        public int OwnerId
        {
            get => _ownerId;
        }

        private readonly string _name;
        public string Name
        {
            get => _name;
        }

        private List<int> _cardsIds;
        public List<int> CardsIds
        {
            get => _cardsIds;
        }
        
        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */

        public Project(int id, int ownerId, string name)
        {
            _id = id;
            _ownerId = ownerId;
            _name = name;
            _cardsIds = new List<int>();
        }
        
        /*
        * ==========================================
        * METHODS
        * ==========================================
        */

        /// <summary>
        /// Adds a card to the list of cards for this project.
        /// </summary>
        /// <param name="cardId">An integer number representing the Id of the card to be added to the project.</param>
        public void AddCard(int cardId)
        {
            _cardsIds.Add(cardId);
        }

        /// <summary>
        /// Removes a card from the list of cards for this project.
        /// </summary>
        /// <param name="cardId">An integer number representing the Id of the card to be removed from the project.</param>
        public void RemoveCard(int cardId)
        {
            _cardsIds.Remove(cardId);
        }
    }
}