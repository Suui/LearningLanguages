using System;


namespace Domain
{
	public class User
	{
		public Guid Id { get; }
		public string Name { get; }
		public string Password { get; }
		public string Email { get; }

		public User(Guid id, string name, string password, string email)
		{
			Id = id;
			Email = email;
			Name = name;
			Password = password;
		}
	}
}