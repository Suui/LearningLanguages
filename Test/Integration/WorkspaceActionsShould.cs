using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Actions;
using Domain.Actions.Workspace;
using FluentAssertions;
using MongoDB.Driver;
using NUnit.Framework;
using Persistence;
using Test.Helpers;

/* TODO
 - Create and retrieve folders for the current user
*/

namespace Test.Integration
{
	[TestFixture]
	public class WorkspaceActionsShould : MongoTest
	{
		[Test]
		public void create_a_vocabulary_folder()
		{
			const string folderName = "Parrot Words";
			var workspaceRepository = new MongoWorkspaceRepository(TestDatabase);

			new CreateVocabularyFolder(workspaceRepository).execute(folderName);

			var folders = GetVocabularyFolders();
			folders.Count.Should().Be(1);
			folders.Single().Name.Should().Be(folderName);
		}

		[Test]
		public void retrieve_all_vocabulary_folders()
		{
			var workspaceRepository = new MongoWorkspaceRepository(TestDatabase);
			var firstFolder = new Folder(Guid.NewGuid(), "first");
			var secondFolder = new Folder(Guid.NewGuid(), "second");
			GivenTwoFolders(firstFolder, secondFolder);

			var folders = new RetrieveVocabularyFolders(workspaceRepository).execute();

			folders.Count.Should().Be(2);
			folders.Find(folder => folder.Id == firstFolder.Id).Name.Should().Be(firstFolder.Name);
			folders.Find(folder => folder.Id == secondFolder.Id).Name.Should().Be(secondFolder.Name);
		}

		private void GivenTwoFolders(Folder first, Folder second)
		{
			var folderCollection = TestDatabase.GetCollection<Folder>("folders");
			folderCollection.InsertMany(new List<Folder> { first, second });
		}

		private List<Folder> GetVocabularyFolders()
		{
			var folderCollection = TestDatabase.GetCollection<Folder>("folders");
			var folders = folderCollection.Find(folder => true).ToList();
			return folders;
		}
	}
}