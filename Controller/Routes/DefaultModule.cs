using Nancy;
using Nancy.Security;


namespace Controller.Routes
{
	public class DefaultModule : NancyModule
	{
		public DefaultModule()
		{
			Get["/content/{any*}"] = parameters =>
			{
				string path = parameters.any;
				return Response.AsFile(path);
			};

			Get["/"] = _ =>
			{
				this.RequiresAuthentication();
				return View["index"];
			};

			Get["/{any*}"] = _ =>
			{
				this.RequiresAuthentication();
				return View["index"];
			};
		}
	}
}