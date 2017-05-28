using System.Collections.Generic;
using System.Linq;
using Domain;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Persistence;
using Test.Helpers;


namespace Test.Unit
{
	[TestFixture]
	public class CreateVocabularyFolderShould : MongoTest
	{
		[Test]
		public void create_the_vocabulary_folder()
		{
			const string folderName = "Parrot Words";
			var workspaceRepository = new MongoWorkspaceRepository(TestDatabase);

			new CreateVocabularyFolder(workspaceRepository).execute(folderName);

			var folders = GetVocabularyFolders();
			folders.Count.Should().Be(1);
			folders.Single().Name.Should().Be(folderName);
		}

		private List<Folder> GetVocabularyFolders()
		{
			var folderCollection = TestDatabase.GetCollection<Folder>("folders");
			var folders = folderCollection.Find(folder => true).ToList();
			return folders;
		}
	}
}