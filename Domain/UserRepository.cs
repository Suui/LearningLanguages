using System;


namespace Domain
{
	public interface UserRepository
	{
		Guid GetUserGuid(string username, string password);

		string GetUsernameFrom(Guid identifier);
	}
}