using Domain.Repositories;


namespace Domain.Actions.User
{
	public class RetrieveUserAction
	{
		private UserRepository UserRepository { get; }

		public RetrieveUserAction(UserRepository userRepository)
		{
			UserRepository = userRepository;
		}

		public Domain.User Execute(string username)
		{
			return UserRepository.RetrieveUserWith(username);
		}
	}
}