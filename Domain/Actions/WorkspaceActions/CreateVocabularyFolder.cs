using System;
using Domain.Repositories;


namespace Domain.Actions.WorkspaceActions
{
	public class CreateVocabularyFolder
	{
		public WorkspaceRepository WorkspaceRepository { get; set; }

		public CreateVocabularyFolder(WorkspaceRepository workspaceRepository)
		{
			WorkspaceRepository = workspaceRepository;
		}

		public void Execute(string folderName, User user)
		{
			var folder = new Folder(Guid.NewGuid(), folderName);
			WorkspaceRepository.Create(folder, user);
		}
	}
}