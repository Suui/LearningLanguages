using System.Text;
using Domain.Actions.UserActions;
using Domain.Actions.WorkspaceActions;
using Nancy;
using Nancy.Extensions;
using Nancy.Security;
using Persistence;


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

				var username = Context.CurrentUser.UserName;
				var user = new RetrieveUserAction(PersistenceFactory.UserRepository()).Execute(username);
				/*new CreateVocabularyFolder(PersistenceFactory.WorkspaceRepository()).Execute(folderName, );*/

//				new CreateVocabularyFolder(PersistenceFactory.FolderRepository()).Execute();
//				var folder = new RetrieveVocabularyFolder(PersistenceFactory.FolderRepository()).Execute();

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