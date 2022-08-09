using RogoffMediaLibrary.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RogoffMediaLibrary.Models;

public class PostModel
{
    public PostModel()
    {

    }

    [Required]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OriginalAuthorId { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(512)]
    public string? OriginalContent { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public bool IsEdited { get; set; } = false;
    public string? EditedContent { get; set; }
    public DateTime? DateTimeEdited { get; set; }
    public int Likes { get; set; }
    public List<int>? RepostListOfIds { get; set; }
    public PostStatus Status { get; set; }
    public DateTime? DateTimeLastStatusChange { get; set; }
    public BanReason? ReasonForRemoval { get; set; }
    public string? RemovalDetails { get; set; }
    public ICollection<CommentModel> Comments { get; set; }
    
    public virtual UserModel User { get; set; }
}
