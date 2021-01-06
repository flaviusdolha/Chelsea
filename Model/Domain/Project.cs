using System;
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
        public int Id => _id;

        private readonly int _ownerId;
        public int OwnerId => _ownerId;

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (Name.Length <= 128) _name = value;
                else throw new ArgumentOutOfRangeException("Project's name must have maximum 128 characters.");
            }
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
        }
    }
}