using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        //private readonly CarsRepository _carsRepository = new CarsRepository();
        private readonly CarsRepositoryDB _carsRepository;

        public CarsController(CarsRepositoryDB carsRepositoryDB)
        {
            _carsRepository = carsRepositoryDB;
        }

        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            IEnumerable<Car> cars = _carsRepository.GetAllCars();

            if (cars.Any())
            {
                Response.Headers.Append("TotalCount", cars.Count().ToString());
                return Ok(cars);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            Car? car = _carsRepository.GetCarById(id);
            if (car != null)
            {
                return Ok(car);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car car = _carsRepository.AddCar(newCar);
                return Created("/", newCar);
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Car?> Put(int id, [FromBody] Car car)
        {
            try
            {
                Car? updatedCar = _carsRepository.UpdateCar(car);
                if (updatedCar != null)
                {
                    return Ok(updatedCar);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is ArgumentNullException)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car deletedCar = _carsRepository.DeleteCar(id);
            if (deletedCar != null)
            {
                return Ok(deletedCar);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
