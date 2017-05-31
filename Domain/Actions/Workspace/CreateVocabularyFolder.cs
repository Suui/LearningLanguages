using System;
using Domain.Repositories;


namespace Domain.Actions.Workspace
{
	public class CreateVocabularyFolder
	{
		public WorkspaceRepository WorkspaceRepository { get; set; }

		public CreateVocabularyFolder(WorkspaceRepository workspaceRepository)
		{
			WorkspaceRepository = workspaceRepository;
		}

		public void execute(string folderName)
		{
			var folder = new Folder(Guid.NewGuid(), folderName);
			WorkspaceRepository.Create(folder);
		}
	}
}