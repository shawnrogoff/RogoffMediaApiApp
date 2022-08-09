using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RogoffMediaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary.TableConfigurations;

internal class PostConfiguration : IEntityTypeConfiguration<PostModel>
{
    private const string TableName = "posts";

    public void Configure(EntityTypeBuilder<PostModel> builder)
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
           .HasColumnName("OriginalAuthorId")
           .HasColumnType("int");

        builder.Property(x => x.OriginalAuthorId)
            .HasColumnName("OriginalAuthorId")
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

        builder.Property(x => x.RepostListOfIds)
            .HasColumnName("RepostListOfIds")
            .HasColumnType("varchar(max)");

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

        builder.Property(x => x.Comments)
           .HasColumnName("Comments")
           .HasColumnType("varchar(max)");

        // Posts created by a User with User.Id
        builder.HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.Id)
            .HasConstraintName("ForeignKey_Post_User");
    }




}
