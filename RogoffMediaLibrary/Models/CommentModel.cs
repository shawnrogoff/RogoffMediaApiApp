using RogoffMediaLibrary.Enums;
using System.ComponentModel.DataAnnotations;

namespace RogoffMediaLibrary.Models;

public class CommentModel
{
    public CommentModel()
    {

    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
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
    public ICollection<CommentModel> Replies { get; set; }

    public virtual PostModel Post { get; set; }

    public virtual UserModel User { get; set; }
}
