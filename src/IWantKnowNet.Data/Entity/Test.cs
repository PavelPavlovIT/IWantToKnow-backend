using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class Test
{
    [MaxLength(255)] public required string Id { get; set; }
    
    [MaxLength(500)] public required string CategoryName { get; set; }
    public required DateTimeOffset Created { get; set; }
    public DateTimeOffset? Started { get; set; }
    public int CountQuestions { get; set; } = 60;
    public bool Finished { get; set; }

    [MaxLength(255)] public required string UserId { get; set; }
    public ApplicationUser? User { get; set; }

    [MaxLength(255)] public required string CategoryId { get; set; }
    public Category? Category { get; set; }

    [MaxLength(255)] public required string TypeTestId { get; set; }
    [MaxLength(255)] public TypeTest? TypeTest { get; set; }


    public ICollection<Answer>? Answers { get; }
    public ICollection<TestResult>? TestResults { get; }
}