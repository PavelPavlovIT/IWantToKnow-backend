using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class MemberTeam
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string MentorId { get; set; }
    [MaxLength(255)] public string? MemeberId { get; set; }
    [MaxLength(500)] public required string Email { get; set; }
    [MaxLength(100)] public required string Nickname { get; set; }
    public required bool IsActive { get; set; }
}