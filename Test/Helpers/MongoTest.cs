using MongoDB.Driver;
using NUnit.Framework;


namespace Test.Helpers
{
	[TestFixture]
	public class MongoTest
	{
		private const string DatabaseName = "test-learning-languages";
		protected IMongoDatabase TestDatabase { get; set; }

		[SetUp]
		public void create_database()
		{
			TestDatabase = new MongoClient().GetDatabase(DatabaseName);
		}

		[TearDown]
		public void drop_database()
		{
			new MongoClient().DropDatabase(DatabaseName);
		}
	}
}