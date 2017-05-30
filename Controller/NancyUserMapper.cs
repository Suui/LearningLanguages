using System;
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
			var userRepository = PersistenceFactory.UserRepository();
			var username = userRepository.RetrieveUserWith(identifier).Name;
			return new NancyUserIdentity { UserName = username };
		}
	}
}