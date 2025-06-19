using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class ApplicationUser : IdentityUser
{
    [MaxLength(50)] public string Language { get; set; }
    public DateTime? ExpireDateTime { get; set; }

    public ICollection<Category>? Categories { get; }
    public ICollection<Question>? Questions { get; }
    public ICollection<CorrectAnswer>? CorrectAnswers { get; }
    
    public ICollection<IncorrectAnswer>? IncorrectAnswers { get; }
}