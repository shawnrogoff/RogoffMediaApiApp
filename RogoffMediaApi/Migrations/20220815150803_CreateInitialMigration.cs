using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RogoffMediaApi.Migrations
{
    public partial class CreateInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "binary", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DateTimeLastDisplayNameChange = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateTimeLastEmailChange = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Status = table.Column<string>(type: "varchar(64)", nullable: false),
                    DateTimeLastStatusChange = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ReasonForRemoval = table.Column<string>(type: "varchar(64)", nullable: true),
                    RemovalDetails = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    RemovalTimeframe = table.Column<string>(type: "varchar(32)", nullable: true),
                    AccountStrikes = table.Column<int>(type: "int", nullable: false),
                    AboutContent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    ProfilePictureData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProfilePictureFiletype = table.Column<string>(type: "varchar(16)", nullable: true),
                    Following = table.Column<string>(type: "varchar(max)", nullable: true),
                    Followers = table.Column<string>(type: "varchar(max)", nullable: true),
                    Posts = table.Column<string>(type: "varchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalAuthorId = table.Column<int>(type: "int", nullable: false),
                    OriginalContent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false),
                    EditedContent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DateTimeEdited = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(64)", nullable: false),
                    DateTimeLastStatusChange = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ReasonForRemoval = table.Column<string>(type: "varchar(64)", nullable: true),
                    RemovalDetails = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    RepostListOfIds = table.Column<string>(type: "varchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Post_User",
                        column: x => x.OriginalAuthorId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalContent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false),
                    EditedContent = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DateTimeEdited = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(64)", nullable: false),
                    DateTimeLastStatusChange = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ReasonForRemoval = table.Column<string>(type: "varchar(64)", nullable: true),
                    RemovalDetails = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Replies = table.Column<string>(type: "varchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Comment_Post",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "ForeignKey_Comment_User",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "Id",
                table: "comments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_PostId",
                table: "comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Id",
                table: "posts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_OriginalAuthorId",
                table: "posts",
                column: "OriginalAuthorId");

            migrationBuilder.CreateIndex(
                name: "Id",
                table: "users",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
