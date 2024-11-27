using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaspberryPuppyAPI.Controllers
{
	[Route("RaspbarryPuppy")]
	[ApiController]
	public class PuppyController : ControllerBase
	{
		// GET: api/<PuppyController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<PuppyController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<PuppyController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<PuppyController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PuppyController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
