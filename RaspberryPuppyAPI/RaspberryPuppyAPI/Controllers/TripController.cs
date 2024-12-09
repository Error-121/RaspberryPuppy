using Microsoft.AspNetCore.Mvc;
using RaspberryPuppy;
using RaspberryPuppy.EFDbContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaspberryPuppyAPI.Controllers
{
	[Route("Trip")]

	[ApiController]

	public class TripController : ControllerBase
	{
        private readonly PuppyDbContext _context;
        private readonly GenericPuppyRepo<TripData> _tripRepo;


        public TripController(PuppyDbContext context, GenericPuppyRepo<TripData> tripRepo)
        {
            _context = context;
            _tripRepo = tripRepo;
        }

        [HttpGet]
        public IEnumerable<TripData> GetAllTrips()
        {
            return _tripRepo.GetAll();
        }


  //      // GET api/<PuppyController>/5
  //      [ProducesResponseType(StatusCodes.Status200OK)]
  //      [ProducesResponseType(StatusCodes.Status404NotFound)]
  //      [HttpGet("{id}")]
  //      public ActionResult<Puppy> GetById(int id)
  //      {
  //          Puppy? aPuppy = _repository.GetByID(id);
  //          if (aPuppy == null)
  //          {
  //              return NotFound();
  //          }
  //          else
  //              return Ok(aPuppy);
  //      }

  //      [HttpPost]
  //      public Puppy Post([FromBody] Puppy value)
  //      {
  //          return _repository.Add(value);
  //      }

  //      // PUT api/<PuppyController>/
  //      [HttpPut("{id}")]
  //      public Puppy? Put(int id, [FromBody] Puppy value)
  //      {
  //          return _repository.Update(id, value);
  //      }

  //      // DELETE api/<PuppyController>/5
  //      [HttpDelete("{id}")]
		//public void Delete(int id)
		//{
  //          _repository.Delete(id);
  //      }
	}
}
