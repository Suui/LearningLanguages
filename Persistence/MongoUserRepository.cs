using System;
using System.Linq;
using Domain;
using Domain.Repositories;
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

		public User RetrieveUserWith(Guid userId)
		{
			return UserCollection.Find(user => user.Id == userId).ToList().Single();
		}

		public User RetrieveUserWith(string username)
		{
			return UserCollection.Find(user => user.Name == username).ToList().Single();
		}

		public Guid RetrieveUserIdFor(string username, string password)
		{
			var matchingUsers = UserCollection.Find(user => user.Name == username && user.Password == password).ToList();
			if (matchingUsers.Count == 1)
				return matchingUsers.Single().Id;

			return Guid.Empty;
		}
	}
}