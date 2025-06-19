using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class AssignTest
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string MentorId { get; set; }
    [MaxLength(255)] public required string MemberId { get; set; }
    [MaxLength(255)] public required string TestId { get; set; }
    public required DateTimeOffset Created { get; set; }
    public DateTimeOffset Canceled { get; set; }
}