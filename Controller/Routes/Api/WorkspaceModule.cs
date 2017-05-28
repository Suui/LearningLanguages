using System.Text;
using Nancy;
using Nancy.Extensions;
using Nancy.Security;


namespace Controller.Routes.Api
{
	public class WorkspaceModule : NancyModule
	{
		public WorkspaceModule() : base("/api/workspace")
		{
			this.RequiresAuthentication();

			Post["/vocabulary/folder"] = _ =>
			{
				var json = Json.Parse(Request.Body.AsString());
				var folderName = Json.Deserialize<string>(json["name"]);

//				new CreateVocabularyFolder(folderName, repo).execute();
//				var folder = new RetrieveVocabularyFolder(folderName, repo).execute();

//				var jsonBytes = Encoding.UTF8.GetBytes(Json.Serialize());
//				return new Response
//				{
//					ContentType = "application/json",
//					Contents = s => s.Write(jsonBytes, 0, jsonBytes.Length),
//					StatusCode = HttpStatusCode.OK
//				};
				return HttpStatusCode.Created;
			};
		}
	}
}