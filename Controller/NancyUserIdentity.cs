using System.Collections.Generic;
using Nancy.Security;


namespace Controller
{
	public class NancyUserIdentity : IUserIdentity
	{
		public string UserName { get; set; }
		public IEnumerable<string> Claims { get; }
	}
}