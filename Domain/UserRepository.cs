using System;


namespace Domain
{
	public interface UserRepository
	{
		Guid GetUserGuid(string username, string password);

		User RetrieveUserWith(string username);

		string GetUsernameFrom(Guid identifier);
	}
}