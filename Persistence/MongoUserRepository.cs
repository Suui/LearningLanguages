using System;
using System.Linq;
using Domain;
using MongoDB.Driver;

namespace Persistence
{
	public class MongoUserRepository : UserRepository
	{
		public IMongoCollection<User> UserCollection { get; set; }

		public MongoUserRepository(IMongoDatabase database)
		{
			UserCollection = database.GetCollection<User>("users");
		}

		public Guid GetUserGuid(string username, string password)
		{
			throw new NotImplementedException();
		}

		public string GetUsernameFrom(Guid identifier)
		{
			throw new NotImplementedException();
		}

		public User RetrieveUserWith(string username)
		{
			return UserCollection.Find(user => user.Name == username).ToList().Single();
		}

		public User RetrieveUserWith(Guid id)
		{
			return UserCollection.Find(user => user.Id == id).ToList().Single();
		}
	}
}