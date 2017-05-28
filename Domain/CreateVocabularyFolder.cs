using System;


namespace Domain
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