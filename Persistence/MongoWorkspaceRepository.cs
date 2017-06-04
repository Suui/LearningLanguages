using System;
using System.Collections.Generic;
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

		public List<Folder> RetrieveAllVocabularyFolders()
		{
			var folderCollection = Database.GetCollection<Folder>("folders");
			return folderCollection.Find(folder => true).ToList();
		}
	}
}