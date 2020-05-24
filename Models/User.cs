
using System.ComponentModel.DataAnnotations;

namespace Myo.Models
{
    public class User 
    {

        [Key]
        public int IdUser { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}