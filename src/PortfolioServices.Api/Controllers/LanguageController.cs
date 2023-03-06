using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PortfolioServices.Context.Interfaces;
using PortfolioServices.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioServices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IGenericDAL<Language> lr;

        public LanguageController(IGenericDAL<Language> lr)
        {
            this.lr = lr;
        }

        // GET: api/<LanguageController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await lr.FindAllAsync());
        }

        // GET api/<LanguageController>
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] ObjectId id)
        {
            return Ok(await lr.FindByIdAsync(id));
        }

        // POST api/<LanguageController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Language value)
        {
            await lr.CreateAsync(value);

            return StatusCode(201);
        }


        // PUT api/<LanguageController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Language value)
        {
            await lr.UpdateAsync(value);

            return Ok();
        }

        // DELETE api/<LanguageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(ObjectId id)
        {
            await lr.DeleteByIdAsync(id);

            return Ok();
        }
    }
}
