using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class Category
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public string? ParentId { get; set; }
    [MaxLength(500)] public required string NameEn { get; set; }
    [MaxLength(500)] public required string NameEs { get; set; }
    [MaxLength(500)] public required string NameRu { get; set; }
    [MaxLength(1000)] public required string? DescriptionEn { get; set; }
    [MaxLength(1000)] public required string? DescriptionEs { get; set; }
    [MaxLength(1000)] public required string? DescriptionRu { get; set; }
    [MaxLength(255)] public required string CreaterId { get; set; }
    public ApplicationUser? Creater { get; set; }
    public int OrderBy { get; set; }
    public int CountQuestions { get; set; }
    public bool Hidden { get; set; }
    public bool Reverse { get; set; } 

    public ICollection<Test>? Tests { get; }
}