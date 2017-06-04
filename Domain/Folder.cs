using System;


namespace Domain
{
	public class Folder
	{
		public Guid Id { get; }
		public string Name { get; }

		public Folder(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}