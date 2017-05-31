using System.Collections.Generic;


namespace Domain.Repositories
{
	public interface WorkspaceRepository
	{
		void Create(Folder folder);

		List<Folder> RetrieveAllVocabularyFolders();
	}
}