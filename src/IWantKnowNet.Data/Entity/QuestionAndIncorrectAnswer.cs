using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using IWantToKnowNet.Common.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IWantKnowNet.Data.Entity;

[Index(nameof(QuestionId), nameof(IncorrectAnswerId), IsUnique = true)]
public class QuestionAndIncorrectAnswer
{
    [MaxLength(255)] public required string Id { get; init; }

    [MaxLength(255)] public required string QuestionId { get; set; }
    [MaxLength(255)] public required string IncorrectAnswerId { get; init; }

}