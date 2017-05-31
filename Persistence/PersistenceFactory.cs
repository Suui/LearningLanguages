using System;
using System.Linq;
using MongoDB.Driver;


namespace Persistence
{
	public class PersistenceFactory
	{
		private static IMongoDatabase Database { get; set; }

		public static MongoUserRepository UserRepository()
		{
			return new MongoUserRepository(GetDatabase());
		}

		private static IMongoDatabase GetDatabase()
		{
			if (Database == null)
			{
				if (Environment.GetCommandLineArgs().Any(argument => argument.Contains("/port:18080")))
					Database = new MongoClient().GetDatabase("test-learning-languages");
				else
					Database = new MongoClient().GetDatabase("learning-languages");
			}
			return Database;
		}
	}
}