using MongoDB.Driver;
using NUnit.Framework;


namespace Test.Helpers
{
	[TestFixture]
	public class MongoTest
	{
		private const string DatabaseName = "learning-languages";
		protected IMongoDatabase TestDatabase { get; set; }

		[OneTimeSetUp]
		public void create_database()
		{
			TestDatabase = new MongoClient().GetDatabase(DatabaseName);
		}

		[OneTimeTearDown]
		public void drop_database()
		{
			new MongoClient().DropDatabase(DatabaseName);
		}
	}
}