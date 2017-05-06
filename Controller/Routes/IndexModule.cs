using Nancy;


namespace Controller.Routes
{
	public class IndexModule : NancyModule
	{
		public IndexModule()
		{
			Get["/"] = _ => View["index"];

			Get["/{all*}"] = _ => View["index"];
		}
	}
}