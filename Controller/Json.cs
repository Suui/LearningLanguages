using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace Controller
{
	public class Json
	{
		public static JObject Parse(string json) => JObject.Parse(json);

		public static T Deserialize<T>(JToken token) => JsonConvert.DeserializeObject<T>(token.ToString());

		public static string Serialize(object model)
		{
			return JsonConvert.SerializeObject(model,
				Formatting.None,
				new JsonSerializerSettings
				{
					ContractResolver = new CamelCasePropertyNamesContractResolver()
				});
		}
	}
}