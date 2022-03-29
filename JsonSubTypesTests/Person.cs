using JsonSubTypes;
using Newtonsoft.Json;

namespace JsonSubTypesTests
{
    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Employee), nameof(Employee.JobTitle))]
    [JsonSubtypes.KnownSubTypeWithProperty(typeof(Artist), nameof(Artist.Skill))]
    public class Person
    {
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
        public string Skill { get; set; }
    }
}
