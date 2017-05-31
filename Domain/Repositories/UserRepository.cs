using System;


namespace Domain.Repositories
{
	public interface UserRepository
	{
		Guid RetrieveUserIdFor(string username, string password);

		User RetrieveUserWith(string username);
	}
}