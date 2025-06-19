using System.ComponentModel.DataAnnotations;

namespace IWantKnowNet.Data.Entity;

public class TypeTest
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(100)] public required string Name { get; set; }
}