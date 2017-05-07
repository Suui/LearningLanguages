using System;


namespace Domain
{
	public class UserService
	{
		private UserRepository UserRepository { get; }

		public UserService(UserRepository userRepository)
		{
			UserRepository = userRepository;
		}

		public Guid ValidateUserWith(string username, string password)
		{
			return UserRepository.GetUserGuid(username, password);
		}

		public string GetUsernameFrom(Guid identifier)
		{
			return UserRepository.GetUsernameFrom(identifier);
		}
	}
}
