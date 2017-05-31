using System.Collections.Generic;
using Controller;
using FluentAssertions;
using NUnit.Framework;


namespace Test.Unit
{
	[TestFixture]
	public class JsonShould
	{
		[Test]
		public void deserialize_primitives()
		{
			var json = Json.Parse("{\"number\": 1}");
			
			Json.Deserialize<int>(json["number"]).Should().Be(1);
		}

		[Test]
		public void deserialize_containers()
		{
			var json = Json.Parse("{\"list\": [ 1, 2, 3 ]}");

			Json.Deserialize<List<int>>(json["list"]).ShouldBeEquivalentTo(new List<int> { 1, 2, 3 });
		}

		[Test]
		public void deserialize_objects()
		{
			var personObject = new Person { Name = "Any Name", Age = 20 };
			var json = Json.Parse("{\"person\": { \"name\": \"Any Name\", \"age\": 20 }}");
			Json.Deserialize<Person>(json["person"]).ShouldBeEquivalentTo(personObject);
		}

		internal class Person
		{
			public string Name { get; set; }
			public int Age { get; set; }
		}
	}
}
