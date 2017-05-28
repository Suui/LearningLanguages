using System.Collections.Generic;


namespace Domain
{
	public class RetrieveVocabularyFolders
	{
		public WorkspaceRepository WorkspaceRepository { get; }

		public RetrieveVocabularyFolders(WorkspaceRepository workspaceRepository)
		{
			WorkspaceRepository = workspaceRepository;
		}

		public List<Folder> execute()
		{
			return WorkspaceRepository.RetrieveAllVocabularyFolders();
		}
	}
}