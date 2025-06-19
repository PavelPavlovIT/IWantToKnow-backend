using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWantKnowNet.Data.Entity;

public class Payment
{
    [MaxLength(255)] public required string Id { get; set; }
    [MaxLength(255)] public required string UserId { get; set; }
    public required DateTime Created { get; set; }
    [MaxLength(255)] public required string TxId { get; set; }
    public required decimal Amount { get; set; }
    public bool Success { get; set; }
}