using System.Collections.Generic;


namespace Domain
{
	public interface WorkspaceRepository
	{
		void Create(Folder folder);

		List<Folder> RetrieveAllVocabularyFolders();
	}
}