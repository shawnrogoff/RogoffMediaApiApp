﻿using RogoffMediaLibrary.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RogoffMediaLibrary.Models;

public class UserModel
{
    public UserModel()
    {

    }

    public int Id { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(256)]
    public string UserName { get; set; }
    
    // convert to a byte[] to store in db as binary
    [Required]
    public string Password { get; set; }
    [MinLength(2)]
    [MaxLength(256)]
    public string? DisplayName { get; set; }
    public DateTime DateTimeLastDisplayNameChange { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public DateTime DateTimeLastEmailChange { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public AccountStatus Status { get; set; }
    public DateTime DateTimeLastStatusChange { get; set; }
    public BanReason? ReasonForRemoval { get; set; }
    public string? RemovalDetails { get; set; }
    public BanTimeframe? RemovalTimeframe { get; set; }
    public int? AccountStrikes { get; set; }
    public string? AboutContent { get; set; }
    public byte[]? ProfilePictureData { get; set; }
    public string? ProfilePictureFiletype { get; set; }
    public string? FollowingIdString { get; set; }
    public string? FollowersIdString { get; set; }
    public string? PostsIdString { get; set; }
    public string? CommentsIdString { get; set; }

    [NotMapped]
    public List<int>? FollowingIds { get; set; }
    [NotMapped]
    public List<int>? FollowerIds { get; set; }
    //[NotMapped]
    //public List<int>? Posts { get; set; }
    //[NotMapped]
    //public List<int>? Comments { get; set; }

    public virtual ICollection<PostModel> Posts { get; set; }
    public virtual ICollection<CommentModel> Comments { get; set; }
}
