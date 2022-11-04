using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebSafeExam1.Entities;

public class BlogEntity
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public string UserId { get; set; }
}