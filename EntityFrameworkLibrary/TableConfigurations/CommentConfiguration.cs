using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RogoffMediaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary.TableConfigurations;

internal class CommentConfiguration : IEntityTypeConfiguration<CommentModel>
{
    private const string TableName = "comments";

    public void Configure(EntityTypeBuilder<CommentModel> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.HasIndex(x => x.Id)
            .HasDatabaseName("Id")
            .IsUnique();

        builder.Property(x => x.UserId)
                    .HasColumnName("UserId")
                    .HasColumnType("int");

        builder.Property(x => x.PostId)
                    .HasColumnName("PostId")
                    .HasColumnType("int");

        builder.Property(x => x.OriginalContent)
            .HasColumnName("OriginalContent")
            .HasMaxLength(512)
            .HasColumnType("nvarchar(512)")
            .IsRequired();

        builder.Property(x => x.DateTimeCreated)
            .HasColumnName("DateTimeCreated")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.IsEdited)
            .HasColumnName("IsEdited")
            .HasColumnType("bit");

        builder.Property(x => x.EditedContent)
            .HasColumnName("EditedContent")
            .HasMaxLength(512)
            .HasColumnType("nvarchar(512)");

        builder.Property(x => x.DateTimeEdited)
            .HasColumnName("DateTimeEdited")
            .HasColumnType("datetime");

        builder.Property(x => x.Likes)
            .HasColumnName("Likes")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("Status")
            .HasColumnType("varchar(64)")
            .IsRequired();

        builder.Property(x => x.DateTimeLastStatusChange)
            .HasColumnName("DateTimeLastStatusChange")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.ReasonForRemoval)
            .HasColumnName("ReasonForRemoval")
            .HasColumnType("varchar(64)");

        builder.Property(x => x.RemovalDetails)
            .HasColumnName("RemovalDetails")
            .HasMaxLength(256)
            .HasColumnType("varchar(256)");

        builder.Property(x => x.RepliesIdString)
           .HasColumnName("Replies")
           .HasColumnType("varchar(max)");

        // Comments created by a User.Id
        //builder.HasOne(p => p.User)
        //    .WithMany(u => u.Comments)
        //    .HasForeignKey(p => p.UserId)
        //    .HasConstraintName("ForeignKey_Comment_User");

        //// Comments are attached to a specific Post.Id
        //builder.HasOne(p => p.Post)
        //    .WithMany(u => u.Comments)
        //    .HasForeignKey(p => p.PostId)
        //    .HasConstraintName("ForeignKey_Comment_Post");
    }
}
