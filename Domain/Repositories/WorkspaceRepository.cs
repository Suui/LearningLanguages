using System;
using System.Collections.Generic;


namespace Domain.Repositories
{
	public interface WorkspaceRepository
	{
		void Create(Folder folder, Guid vocabularyFolderId, User user);

		List<Folder> RetrieveAllTheVocabularyFoldersOfThe(User user);
	}
}