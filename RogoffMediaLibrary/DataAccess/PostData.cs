using RogoffMediaLibrary.Models;

namespace RogoffMediaLibrary.DataAccess;

public class PostData : IPostData
{
    private readonly ISqlDataAccess _sql;

    public PostData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<List<PostModel?>> GetPostsByUser(int userId)
    {
        return await _sql.LoadData<PostModel?, dynamic>(
            "dbo.spPosts_GetPostsByUser",
            new { UserId = userId },
            "RogoffMedia");
    }

    public async Task<PostModel?> CreatePost(int userId, string postContent)
    {
        var originalContent = postContent;
        var dateTimeCreated = DateTime.UtcNow;

        var results = await _sql.LoadData<PostModel, dynamic>(
            "dbo.spPosts_CreatePost",
            new { 
                    UserId = userId,
                    OriginalContent = originalContent,
                    DateTimeCreated = dateTimeCreated
            },
            "RogoffMedia");

        return results.FirstOrDefault();
    }
}
