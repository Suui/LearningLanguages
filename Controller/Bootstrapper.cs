using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;


namespace Controller
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
		{
			base.RequestStartup(container, pipelines, context);
			FormsAuthentication.Enable(pipelines, new FormsAuthenticationConfiguration
			{
				RedirectUrl = "/login",
				UserMapper = new NancyUserMapper()
			});
		}
	}
}