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
			var user = userRepository.RetrieveUserWith(identifier);
			return new NancyUserIdentity { UserName = user.Name };
		}
	}
}