using System;
using System.Collections.Generic;
using Domain;
using Domain.Actions.WorkspaceActions;
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
		private Folder VocabularyFolder;
		private User User { get; set; }

		[SetUp]
		public void setup()
		{
			User = new User
			(
				id: Guid.NewGuid(),
				name: Any.String(),
				password: Any.String(),
				email: Any.String()
			);

			VocabularyFolder = GivenAVocabularyFolderForThe(User);
		}

		[Test]
		public void create_a_vocabulary_folder()
		{
			const string folderName = "Parrot Words";
			var workspaceRepository = new MongoWorkspaceRepository(TestDatabase);

			new CreateVocabularyFolder(workspaceRepository).Execute(folderName, VocabularyFolder.Id, User);

			var folders = GetVocabularyFoldersForThe(User);
			folders.Should().Contain(folder => folder.Name == folderName);
		}

		[Test]
		public void retrieve_all_vocabulary_folders()
		{
			var workspaceRepository = new MongoWorkspaceRepository(TestDatabase);
			var firstFolder = new Folder(Guid.NewGuid(), "first");
			var secondFolder = new Folder(Guid.NewGuid(), "second");
			GivenTwoFolders(firstFolder, secondFolder);

			var folders = new RetrieveVocabularyFolders(workspaceRepository).Execute(User);

			folders.Count.Should().Be(2);
			folders.Find(folder => folder.Id == firstFolder.Id).Name.Should().Be(firstFolder.Name);
			folders.Find(folder => folder.Id == secondFolder.Id).Name.Should().Be(secondFolder.Name);
		}

		private void GivenTwoFolders(Folder first, Folder second)
		{
			var folderCollection = TestDatabase.GetCollection<FolderDocument>("folders");
			folderCollection.InsertMany(new List<FolderDocument>
			{
				first.AsFolderDocument(VocabularyFolder.Id, User),
				second.AsFolderDocument(VocabularyFolder.Id, User)
			});
		}

		private List<Folder> GetVocabularyFoldersForThe(User user)
		{
			var folderCollection = TestDatabase.GetCollection<FolderDocument>("folders");
			var folderDocuments = folderCollection.Find(folder => user.Id == folder.UserId
															   && folder.ParentFolderId == VocabularyFolder.Id).ToList();
			return folderDocuments.AsFolders(VocabularyFolder);
		}

		private Folder GivenAVocabularyFolderForThe(User user)
		{
			var vocabularyFolder = new Folder(
				id: Guid.NewGuid(),
				name: "Vocabulary"
			);
			var userCollection = TestDatabase.GetCollection<User>("users");
			userCollection.InsertOne(user);
			var folderCollection = TestDatabase.GetCollection<FolderDocument>("folders");
			folderCollection.InsertOne(vocabularyFolder.AsFolderDocument(Guid.Empty, user));
			return vocabularyFolder;
		}
	}
}