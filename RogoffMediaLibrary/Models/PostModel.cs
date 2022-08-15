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
    public PostStatus Status { get; set; }
    public DateTime? DateTimeLastStatusChange { get; set; }
    public BanReason? ReasonForRemoval { get; set; }
    public string? RemovalDetails { get; set; }
    public string? RepostsIdString { get; set; }
    public string? CommentsIdString { get; set; }

    [NotMapped]
    public List<int> RepostIds { get; set; }
    [NotMapped]
    public List<int> CommentIds { get; set; }
    public virtual ICollection<CommentModel> Comments { get; set; }

    [ForeignKey("UserModel")]
    public int UserId { get; set; }
    public virtual UserModel User { get; set; }
}
