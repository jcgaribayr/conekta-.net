using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Conekta
{
    public class Log : Resource
	{
		public async Task<JObject[]> Where(string data = @"{}")
		{
			string result = await this.Where("/logs", data);

			JObject[] logs = JsonConvert.DeserializeObject<JObject[]>(result, new JsonSerializerSettings
            {
				NullValueHandling = NullValueHandling.Ignore
			});

			return logs;
		}
	}
}

