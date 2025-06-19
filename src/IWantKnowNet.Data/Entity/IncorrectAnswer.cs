using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

[Index(nameof(TitleEn), IsUnique = true)]
[Index(nameof(TitleEs), IsUnique = true)]
[Index(nameof(TitleRu), IsUnique = true)]

public class IncorrectAnswer
{
    [MaxLength(255)] public required string Id { get; set; }
    public int IsTerm { get; set; }
    [MaxLength(500)] public required string TitleEn { get; set; }
    [MaxLength(500)] public required string TitleEs { get; set; }
    [MaxLength(500)] public required string TitleRu { get; set; }
    public int OrderBy { get; set; }

    [MaxLength(255)] public required string CreaterId { get; set; }
    public ApplicationUser? Creater { get; set; }

    [MaxLength(255)] public string? ApproverId { get; set; }
}