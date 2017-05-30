using System;
using Domain;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Persistence;
using Test.Helpers;


namespace Test.Integration
{
	[TestFixture]
	class UserRepositoryShould : MongoTest
	{
		private Guid UserId { get; } = Guid.NewGuid();
		private string Username { get; } = "Parroty McParrot";

		[Test]
		public void retrieve_a_user_given_his_id()
		{
			GivenAUser();
			var userRepository = new MongoUserRepository(TestDatabase);

			var user = userRepository.RetrieveUserWith(UserId);

			user.Id.Should().Be(UserId);
			user.Name.Should().Be(Username);
		}

		private void GivenAUser()
		{
			var userCollection = TestDatabase.GetCollection<User>("users");
			userCollection.InsertOne(new User
			(
				id: UserId,
				email: "user@email.com",
				name: Username,
				password: "parroty_pass"
			));
		}
	}
}
