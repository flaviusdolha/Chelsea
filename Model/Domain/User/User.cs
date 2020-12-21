using System.ComponentModel.DataAnnotations;

namespace Chelsea.Model.Domain.User
{
    public class User
    {
        /*
        * ==========================================
        * PROPERTIES
        * ==========================================
        */
        
        private int _id;
        public int Id
        {
            get => _id;
        }
        
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        [DataType(DataType.EmailAddress)]
        private string _email;
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get => _email;
        }

        private string _password;

        public string Password
        {
            get => _password;
        }

        private string _profilePictureUrl;
        public string ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set => _profilePictureUrl = value;
        }

        private Role _role;
        public Role Role
        {
            get => _role;
            set => _role = value;
        }

        /*
        * ==========================================
        * CONSTRUCTORS
        * ==========================================
        */
        
        public User(int id, string firstName, string lastName, string email, string password)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _profilePictureUrl = "";
            _role = Role.Viewer;
        }
    }
}