using System;


namespace Domain
{
	public class User
	{
		public Guid Id { get; }
		public string Email { get; }
		public string Name { get; }
		public string Password { get; }

		public User(Guid id, string email, string name, string password)
		{
			Id = id;
			Email = email;
			Name = name;
			Password = password;
		}
	}
}