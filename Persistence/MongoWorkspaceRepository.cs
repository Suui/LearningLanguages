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
		private IMongoCollection<FolderDocument> FolderCollection { get; }

		public MongoWorkspaceRepository(IMongoDatabase database)
		{
			FolderCollection = database.GetCollection<FolderDocument>("folders");
		}

		public void Create(Folder folder, User user)
		{
			FolderCollection.InsertOne(folder.AsFolderDocument(VocabularyFolder().Id, user));
		}

		public List<Folder> RetrieveAllTheVocabularyFoldersOfThe(User user)
		{
			return FolderCollection.Find(folder => folder.ParentFolderId == VocabularyFolder().Id)
								   .ToList()
								   .Select(folder => folder.AsFolder())
								   .ToList();
		}

		private FolderDocument VocabularyFolder()
		{
			return FolderCollection.Find(folder => folder.ParentFolderId == Guid.Empty
												&& folder.Name.Equals("Vocabulary")).Single();
		}
	}
}