using MongoDB.Driver;


namespace Persistence
{
	public class PersistenceFactory
	{
		public static MongoUserRepository UserRepository()
		{
			return new MongoUserRepository(new MongoClient().GetDatabase("learning-languages"));
		}
	}
}