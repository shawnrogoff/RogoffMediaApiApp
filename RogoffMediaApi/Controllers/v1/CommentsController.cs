using Microsoft.AspNetCore.Mvc;

namespace RogoffMediaApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class CommentsController : ControllerBase
{
    // GET: api/v1/Comments
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/v1/Comments/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/v1/Comments
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/v1/Comments/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/v1/Comments/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
