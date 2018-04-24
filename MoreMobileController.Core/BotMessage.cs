using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoreMobileController.Core
{
    public class BotMessage
    {
        public static BotMessage Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<BotMessage>(json);
        }

        public string Command { get; set; }

        public string Data { get; set; }

        public virtual string Serialize()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
