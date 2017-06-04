using System;


namespace Domain
{
	public class Workspace
	{
		public static Folder RootFolder()
		{
			return new Folder
			(
				id: Guid.Empty,
				name: "root"
			);
		}
	}
}