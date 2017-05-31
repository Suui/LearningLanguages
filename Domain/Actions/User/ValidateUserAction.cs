using System;
using Domain.Repositories;


namespace Domain.Actions.User
{
	public class ValidateUserAction
	{
		private UserRepository UserRepository { get; }

		public ValidateUserAction(UserRepository userRepository)
		{
			UserRepository = userRepository;
		}

		public bool Execute(string username, string password)
		{
			var id = UserRepository.RetrieveUserIdFor(username, password);
			return id != Guid.Empty;
		}
	}
}