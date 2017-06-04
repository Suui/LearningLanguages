using System.Collections.Generic;
using Domain.Repositories;


namespace Domain.Actions.WorkspaceActions
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