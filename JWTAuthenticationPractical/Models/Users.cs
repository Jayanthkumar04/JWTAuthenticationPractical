using System.ComponentModel.DataAnnotations;

namespace JWTAuthenticationPractical.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

    }
}
