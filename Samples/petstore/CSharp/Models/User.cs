
namespace Petstore.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class User
    {
        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User() { }

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        /// <param name="userStatus">User Status</param>
        public User(long? id = default(long?), string username = default(string), string firstName = default(string), string lastName = default(string), string email = default(string), string password = default(string), string phone = default(string), int? userStatus = default(int?))
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            UserStatus = userStatus;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets user Status
        /// </summary>
        [JsonProperty(PropertyName = "userStatus")]
        public int? UserStatus { get; set; }

    }
}

