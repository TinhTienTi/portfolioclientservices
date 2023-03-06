using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PortfolioServices.Context.Interfaces;
using PortfolioServices.Model;

namespace PortfolioServices.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IGenericDAL<Home> hr;

    public HomeController(IGenericDAL<Home> hr)
    {
        this.hr = hr;
    }

    // GET: api/<HomeController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await hr.FindAllAsync());
    }

    // GET api/<HomeController>
    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> GetById([FromQuery]ObjectId id)
    {
        return Ok(await hr.FindByIdAsync(id));
    }

    // POST api/<HomeController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Home value)
    {
        await hr.CreateAsync(value);

        return StatusCode(201);
    }

    // PUT api/<HomeController>
    [HttpPut()]
    public async Task<IActionResult> Put([FromBody] Home value)
    {
        await hr.UpdateAsync(value);

        return Ok();
    }

    // DELETE api/<HomeController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ObjectId id)
    {
        await hr.DeleteByIdAsync(id);

        return Ok();
    }
}
