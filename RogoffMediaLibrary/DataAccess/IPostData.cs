using RogoffMediaLibrary.Models;

namespace RogoffMediaLibrary.DataAccess;

public interface IPostData
{
    Task<PostModel?> CreatePost(int userId, string postContent);
    Task<List<PostModel?>> GetPostsByUser(int userId);
}
