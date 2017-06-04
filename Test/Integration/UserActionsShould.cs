using System;
using Domain;
using Domain.Actions.UserActions;
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
		private const string Password = "parroty_pass";
		private Guid UserId { get; } = Guid.NewGuid();

		[Test]
		public void validate_a_user_given_his_username_and_password()
		{
			GivenAUser();

			var validated = new ValidateUserAction(new MongoUserRepository(TestDatabase)).Execute(Username, Password);
			validated.Should().BeTrue();

			validated = new ValidateUserAction(new MongoUserRepository(TestDatabase)).Execute(Username, "wrong_password");
			validated.Should().BeFalse();
		}

		[Test]
		public void retrieve_a_user_given_his_username()
		{
			GivenAUser();

			var user = new RetrieveUserAction(new MongoUserRepository(TestDatabase)).Execute(Username);

			user.Id.Should().Be(UserId);
		}

		private void GivenAUser()
		{
			var userCollection = TestDatabase.GetCollection<User>("users");
			userCollection.InsertOne(new User
			(
				id: UserId,
				name: Username,
				password: Password, email: "parroty@email.com"
			));
		}
	}
}