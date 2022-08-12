using RogoffMediaLibrary.Models;

namespace RogoffMediaLibrary.DataAccess;

public interface IPostData
{
    Task<PostModel?> CreatePost(int userId, PostModel post);
    Task<List<PostModel?>> GetPostsByUser(int userId);
}
