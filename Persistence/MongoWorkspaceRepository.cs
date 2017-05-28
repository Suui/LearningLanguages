﻿using Domain;
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

		public void Create(Folder folder)
		{
			var folderCollection = Database.GetCollection<Folder>("folders");
			folderCollection.InsertOne(folder);
		}
	}
}