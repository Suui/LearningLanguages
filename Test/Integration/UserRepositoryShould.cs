using System;
using Domain;
using FluentAssertions;
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

		[Test]
		public void return_an_empty_guid_if_the_user_was_not_found()
		{
			GivenAUser();
			var userRepository = new MongoUserRepository(TestDatabase);
			
			var guid = userRepository.RetrieveUserIdFor(Username, "wrong_password");

			guid.Should().Be(Guid.Empty);
		}

		private void GivenAUser()
		{
			var userCollection = TestDatabase.GetCollection<User>("users");
			userCollection.InsertOne(new User
			(
				id: UserId,
				name: Username,
				password: "parroty_pass", email: "user@email.com"));
		}
	}
}
