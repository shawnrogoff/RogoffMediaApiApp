using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RogoffMediaLibrary.Models;

namespace EntityFrameworkLibrary.TableConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    private const string TableName = "users";

    public void Configure(EntityTypeBuilder<UserModel> builder)
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

        builder.Property(x => x.UserName)
            .HasColumnName("UserName")
            .HasMaxLength(256)
            .HasColumnType("varchar(256)")
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnName("PasswordHash")
            .HasColumnType("binary")
            .IsRequired();

        builder.Property(x => x.DisplayName)
            .HasColumnName("DisplayName")
            .HasMaxLength(256)
            .HasColumnType("nvarchar(256)");

        builder.Property(x => x.DateTimeLastDisplayNameChange)
            .HasColumnName("DateTimeLastDisplayNameChange")
            .HasColumnType("datetime");

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(256)
            .HasColumnType("nvarchar(256)")
            .IsRequired();

        builder.Property(x => x.DateTimeLastEmailChange)
            .HasColumnName("DateTimeLastEmailChange")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(x => x.DateTimeCreated)
            .HasColumnName("DateTimeCreated")
            .HasColumnType("datetime")
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

        builder.Property(x => x.RemovalTimeframe)
            .HasColumnName("RemovalTimeframe")
            .HasColumnType("varchar(32)");

        builder.Property(x => x.AccountStrikes)
            .HasColumnName("AccountStrikes")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.AboutContent)
            .HasColumnName("AboutContent")
            .HasMaxLength(512)
            .HasColumnType("nvarchar(512)");

        builder.Property(x => x.ProfilePictureData)
           .HasColumnName("ProfilePictureData")
           .HasColumnType("varbinary(max)");

        builder.Property(x => x.ProfilePictureFiletype)
           .HasColumnName("ProfilePictureFiletype")
           .HasColumnType("varchar(16)");

        builder.Property(x => x.Following)
           .HasColumnName("Following")
           .HasColumnType("varchar(max)");

        builder.Property(x => x.Followers)
           .HasColumnName("Followers")
           .HasColumnType("varchar(max)");

        builder.Property(x => x.Posts)
           .HasColumnName("Posts")
           .HasColumnType("varchar(max)");

        builder.Property(x => x.Comments)
           .HasColumnName("Comments")
           .HasColumnType("varchar(max)");

        
    }
}
