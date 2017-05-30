namespace Domain
{
	public class RetrieveUserAction
	{
		private UserRepository UserRepository { get; }

		public RetrieveUserAction(UserRepository userRepository)
		{
			UserRepository = userRepository;
		}

		public User Execute(string username)
		{
			return UserRepository.RetrieveUserWith(username);
		}
	}
}