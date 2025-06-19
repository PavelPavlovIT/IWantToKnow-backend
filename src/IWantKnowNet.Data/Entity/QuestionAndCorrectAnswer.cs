using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IWantKnowNet.Data.Entity;

[Index(nameof(QuestionId), nameof(CorrectAnswerId), IsUnique = true)]
public class QuestionAndCorrectAnswer
{
    [MaxLength(255)] public required string Id { get; set; }
    
    [MaxLength(255)] public required string QuestionId { get; set; }
    [MaxLength(255)] public required string CorrectAnswerId { get; set; }
}