using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IWantKnowNet.Data.Entity;

[Index(nameof(TitleEn), IsUnique = true)]
[Index(nameof(TitleEs), IsUnique = true)]
[Index(nameof(TitleRu), IsUnique = true)]
public class Question
{
    [MaxLength(255)] public required string Id { get; init; }
    //1 - term, 0 - short phrace, 2 - long phrase, 3 - question
    public int IsTerm { get; set; }
    [MaxLength(500)] public required string TitleEn { get; init; }
    [MaxLength(500)] public required string TitleEs { get; init; }
    [MaxLength(500)] public required string TitleRu { get; init; }
    [MaxLength(1000)] public required string ProofUrlEn { get; init; }
    [MaxLength(1000)] public required string ProofUrlEs { get; init; }
    [MaxLength(1000)] public required string ProofUrlRu { get; init; }
    [MaxLength(50)] public required string KeyS3 { get; set; }
    public required DateTime ExpiredSignedUrlS3 { get; set; }
    [MaxLength(1000)] public required string SignedUrlS3 { get; init; }


    public int OrderBy { get; set; }
    

    [MaxLength(255)] public required string CreaterId { get; init; }
    public ApplicationUser? Creater { get; set; }

    [MaxLength(255)] public string? ApproverId { get; set; }
    [MaxLength(100)] public string? ProofCRCEn { get; set; }
    [MaxLength(100)] public string? ProofCRCEs { get; set; }
    [MaxLength(100)] public string? ProofCRCRu { get; set; }
}