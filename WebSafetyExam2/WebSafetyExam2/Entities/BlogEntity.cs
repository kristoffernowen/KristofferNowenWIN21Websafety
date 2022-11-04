using System.ComponentModel.DataAnnotations;

namespace WebSafetyExam2.Entities
{
    public class BlogEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}
