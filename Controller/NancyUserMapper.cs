using System;
using Domain;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Persistence;


namespace Controller
{
	public class NancyUserMapper : IUserMapper
	{
		public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
		{
			var userService = new UserService(new InMemoryUserRepository());
			return new NancyUserIdentity { UserName = userService.GetUsernameFrom(identifier) };
		}
	}
}