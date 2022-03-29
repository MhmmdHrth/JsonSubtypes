using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JsonSubTypesTests
{
    public class JsonSubTypesTests
    {
        [Fact]
        public void Cast_JsonSubtypes()
        {
            string json = "[{\"Department\":\"Department1\",\"JobTitle\":\"JobTitle1\",\"FirstName\":\"FirstName1\",\"LastName\":\"LastName1\"}," +
                "{\"Department\":\"Department1\",\"JobTitle\":\"JobTitle1\",\"FirstName\":\"FirstName1\",\"LastName\":\"LastName1\"}," +
                "{\"Skill\":\"Painter\",\"FirstName\":\"FirstName1\",\"LastName\":\"LastName1\"}]";

            var persons = JsonConvert.DeserializeObject<IReadOnlyCollection<Person>>(json);
            var actual = (persons.Last() as Artist)?.Skill;
            Assert.Equal("Painter", actual);
        }
    }
}