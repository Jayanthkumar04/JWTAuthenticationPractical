namespace JWTAuthenticationPractical.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
    }
}
