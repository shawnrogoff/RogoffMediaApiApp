using RogoffMediaLibrary.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RogoffMediaLibrary.Models;

public class CommentModel
{
    public CommentModel()
    {

    }

    public int Id { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(512)]
    public string? OriginalContent { get; set; }
    public DateTime DateTimeCreated { get; set; } = DateTime.UtcNow;
    public bool IsEdited { get; set; } = false;
    public string? EditedContent { get; set; }
    public DateTime? DateTimeEdited { get; set; }
    public int Likes { get; set; } = 0;
    public CommentStatus Status { get; set; } = CommentStatus.Clear;
    public DateTime? DateTimeLastStatusChange { get; set; }
    public BanReason? ReasonForRemoval { get; set; }
    public string? RemovalDetails { get; set; }
    public string? RepliesIdString { get; set; }

    [NotMapped]
    public List<int>? Replies { get; set; }

    [ForeignKey("PostModel")]
    public int PostId { get; set; }
    public virtual PostModel Post { get; set; }

    [ForeignKey("UserModel")]
    public int UserId { get; set; }
    public virtual UserModel User { get; set; }
}
