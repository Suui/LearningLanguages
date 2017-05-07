using System;
using Domain;
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
			var userService = new UserService(new InMemoryUserRepository());

			Get["/"] = _ => View["index"];

			Post["/"] = _ =>
			{
				string username = Request.Form.username;
				string password = Request.Form.password;
				var userGuid = userService.ValidateUserWith(username, password);

				if (userGuid == Guid.Empty)
					return Context.GetRedirect("/login?error=true");

				return this.LoginAndRedirect(userGuid, DateTime.UtcNow.AddDays(7));
			};
		}
	}
}