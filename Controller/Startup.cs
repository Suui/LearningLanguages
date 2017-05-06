using Microsoft.Owin.Extensions;
using Owin;


namespace Controller
{
	public class Startup
	{
		public void Configuration(IAppBuilder application)
		{
			application.UseNancy();
			application.UseStageMarker(PipelineStage.MapHandler);
		}
	}
}