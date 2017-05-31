using System;
using Domain.Actions.User;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Extensions;
using Persistence;


namespace Controller.Routes
{
	public class LoginModule : NancyModule
	{
		public LoginModule() : base("/login")
		{
			Get["/"] = _ => View["index"];

			Post["/"] = _ =>
			{
				string username = Request.Form.username;
				string password = Request.Form.password;

				var validated = new ValidateUserAction(PersistenceFactory.UserRepository()).Execute(username, password);
				if (validated)
				{
					var user = new RetrieveUserAction(PersistenceFactory.UserRepository()).Execute(username);
					return this.LoginAndRedirect(user.Id, DateTime.UtcNow.AddDays(7));
				}

				return Context.GetRedirect("/login?error=true");
			};
		}
	}
}