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

        private readonly string _name;
        public string Name => _name;

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