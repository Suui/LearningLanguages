using System;
using Domain;


namespace Persistence
{
    public class InMemoryUserRepository : UserRepository
    {
	    public static Guid UserGuid = Guid.NewGuid();

	    public Guid GetUserGuid(string username, string password)
	    {
		    return username.Equals("CrazyParrot") && password.Equals("parroty_pass") ? UserGuid : Guid.Empty;
	    }

	    public string GetUsernameFrom(Guid identifier)
	    {
		    return identifier == UserGuid ? "CrazyParrot" : string.Empty;
	    }
    }
}
