using System;
using System.Collections.Generic;
using System.Linq;
using Domain;


namespace Persistence
{
	public class FolderDocument
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid UserId { get; set; }
		public Guid ParentFolderId { get; set; }
	}

	public static class FolderDocumentExtensions
	{
		public static FolderDocument AsFolderDocument(this Folder folder, Guid parentFolderId, User user)
		{
			return new FolderDocument
			{
				Id = folder.Id,
				Name = folder.Name,
				UserId = user.Id,
				ParentFolderId = parentFolderId
			};
		}

		public static Folder AsFolder(this FolderDocument folderDocument)
		{
			return new Folder(folderDocument.Id, folderDocument.Name);
		}

		public static List<Folder> AsFolders(this List<FolderDocument> folders, Folder parentFolder)
		{
			return folders.Select(folder => new Folder(folder.Id, folder.Name)).ToList();
		}
	}
}