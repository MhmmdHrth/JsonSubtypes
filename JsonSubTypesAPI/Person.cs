using JsonSubTypes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JsonSubTypesTests
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Employee), nameof(Employee.JobTitle))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Artist), nameof(Artist.Skill))]
    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Employee : Person
    {
        public string Department { get; set; }
        public string JobTitle { get; set; }
    }

    public class Artist : Person
    {
        [MinLength(4)]
        public string Skill { get; set; }
    }
}
