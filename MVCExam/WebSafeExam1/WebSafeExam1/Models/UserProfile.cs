using System.Drawing;

namespace WebSafeExam1.Models
{
    public class UserProfile
    {
        public string Name { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string ProfileImage { get; set; }
    }
}
