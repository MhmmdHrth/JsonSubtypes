using JsonSubTypesTests;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JsonSubTypesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetJsonSubTypes()
        {
            string json = "[{\"Department\":\"Department1\",\"JobTitle\":\"JobTitle1\",\"FirstName\":\"FirstName1\",\"LastName\":\"LastName1\"}," +
                "{\"Department\":\"Department1\",\"JobTitle\":\"JobTitle1\",\"FirstName\":\"FirstName1\",\"LastName\":\"LastName1\"}," +
                "{\"Skill\":\"\",\"FirstName\":\"\",\"LastName\":\"LastName1\"}]";

            var persons = JsonConvert.DeserializeObject<IReadOnlyCollection<Person>>(json);
            var artist = persons.Last() as Artist;
            var context = new ValidationContext(artist);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(artist, context, results, true);
            if (isValid)
            {
                return Ok("Success");
            }

            return BadRequest(new { result = results });
        }
    }
}
