using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }
    [Required]
    [MaxLength(50)]
    public required string MobileNumber{ get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public class Message
{
    [Key]
    public int MessageId { get; set; }
    [ForeignKey("Sender")]
    public int SenderId { get; set; }
    [ForeignKey("Recipient")]
    public required string RecipientId { get; set;}
    [Required]
    public required string MessageText { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;

    public virtual required User Sender { get; set; }
    public virtual required User Recipient { get; set; }
}