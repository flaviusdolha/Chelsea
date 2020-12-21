using System;
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
        public int Id => _id;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (Name.Length <= 128) _name = value;
                else throw new ArgumentOutOfRangeException("Card's name must have maximum 128 characters.");
            }
        }

        private readonly int _projectId;
        public int ProjectId => _projectId;


        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */

        public Card(int id, string name, int projectId)
        {
            _id = id;
            _name = name;
            _projectId = projectId;
        }
    }
}