using System;
using Domain;
using FluentAssertions;
using NUnit.Framework;
using Persistence;
using Test.Helpers;


namespace Test.Integration
{
	[TestFixture]
	public class UserActionsShould : MongoTest
	{
		private const string Username = "Parroty McParrot";

		[Test]
		public void retrieve_a_user_given_his_username()
		{
			GivenAUser();

			var user = new RetrieveUserAction(new MongoUserRepository(TestDatabase)).Execute(Username);

			user.Name.Should().Be(Username);
		}

		private void GivenAUser()
		{
			var userCollection = TestDatabase.GetCollection<User>("users");
			userCollection.InsertOne(new User
			(
				id: Guid.NewGuid(),
				email: "user@email.com",
				name: Username,
				password: "parroty_pass"
			));
		}
	}
}