using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IWantKnowNet.Data.Entity;

[Index(nameof(QuestionId), nameof(CategoryId), IsUnique = true)]
public class CategoryAndQuestion
{
    [MaxLength(255)] public required string Id { get; set; }

    [MaxLength(255)] public required string CategoryId { get; set; }
    [MaxLength(255)] public required string QuestionId { get; set; }
    
}