using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RogoffMediaApi.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class UsersController : ControllerBase
{
    // GET: api/v1/Users
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/v1/Users/5
    [AllowAnonymous]
    [HttpGet("{id}")]
    public string Get(int id)
    {
        string fileName = "appsettings.json";
        string path = Path.Combine(Environment.CurrentDirectory, @"RogoffMediaApiApp\RogoffMediaApi\", fileName);

        string basePath = Path.Combine(Environment.CurrentDirectory, @"RogoffMediaApiApp\RogoffMediaApi\");

        return basePath;
    }

    // POST api/v1/Users
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/v1/Users/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/v1/Users>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
