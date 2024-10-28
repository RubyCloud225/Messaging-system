using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [MaxLength(50)]
    public string MobileNumber{ get; set; }
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
    public string RecipientId { get; set;}
    [Required]
    public string MessageText { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;

    public virtual User Sender { get; set; }
    public virtual User Recipient { get; set; }
}