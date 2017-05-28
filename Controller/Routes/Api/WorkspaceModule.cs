using Nancy;
using Nancy.Security;


namespace Controller.Routes.Api
{
	public class WorkspaceModule : NancyModule
	{
		public WorkspaceModule() : base("/api")
		{
			this.RequiresAuthentication();

			/*Post["/"] = _ =>
			{
				var body = Json.Parse()
			}*/
		}
	}
}