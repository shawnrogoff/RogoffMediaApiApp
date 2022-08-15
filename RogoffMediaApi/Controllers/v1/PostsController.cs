using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RogoffMediaLibrary.DataAccess;
using RogoffMediaLibrary.Models;
using System.Security.Claims;

namespace RogoffMediaApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class PostsController : ControllerBase
{
    private readonly IPostData _data;
    private readonly ILogger<PostsController> _logger;

    public PostsController(IPostData data, ILogger<PostsController> logger)
    {
        _data = data;
        _logger = logger;
    }

    private int GetUserId()
    {
        var userIdText = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return int.Parse(userIdText);
    }

    //GET: api/v1/Posts
   [HttpGet(Name = "GetPosts")]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/v1/Posts/5
    [HttpGet("{userId}", Name = "GetPostsByUser")]
    public async Task<ActionResult<List<PostModel>>> GetPostsByUser(int userId)
    {
        _logger.LogInformation("GET: /Posts/{userId}", userId);

        try
        {
            var output = await _data.GetPostsByUser(userId);
            return Ok(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The GET call to the {ApiPath} failed. The ID was {TodoId}",
                $" /Posts/{userId}",
                userId);
            return BadRequest();
        }
    }


    // POST api/Todos
    [HttpPost(Name = "CreatePost")]
    public async Task<ActionResult<PostModel>> CreatePost([FromBody] string postContent)
    {
        try
        {
            var output = await _data.CreatePost(GetUserId(), postContent);

            return Ok(output);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The POST call to create a post failed");
            return BadRequest();
        }
    }




    // POST api/v1/Posts
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    // PUT api/v1/Posts/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    // DELETE api/v1/Posts/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
