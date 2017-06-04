using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repositories;
using MongoDB.Driver;


namespace Persistence
{
	public class MongoWorkspaceRepository : WorkspaceRepository
	{
		private IMongoDatabase Database { get; }

		public MongoWorkspaceRepository(IMongoDatabase database)
		{
			Database = database;
		}

		public void Create(Folder folder, Guid vocabularyFolderId, User user)
		{
			var folderCollection = Database.GetCollection<FolderDocument>("folders");
			folderCollection.InsertOne(folder.AsFolderDocument(vocabularyFolderId, user));
		}

		public List<Folder> RetrieveAllTheVocabularyFoldersOfThe(User user)
		{
			var folderCollection = Database.GetCollection<FolderDocument>("folders");
			var vocabularyFolder = folderCollection.Find(folder => folder.ParentFolderId == Guid.Empty
																&& folder.Name.Equals("Vocabulary")).Single();
			return folderCollection.Find(folder => folder.ParentFolderId == vocabularyFolder.Id)
								   .ToList().Select(folder => folder.AsFolder()).ToList();
		}
	}
}