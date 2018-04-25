using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoreMobileController.Core
{
    public class PinMessage : BotMessage
    {
        public const string CommandName = "pin";
        public const string OutputMode = "output";
        public const string InputMode = "input";
        public const string WriteHigh = "high";
        public const string WriteLow = "low";
        public const string AnalogWrite = "write";

        public new static PinMessage Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<PinMessage>(json);
        }

        public byte PinNumber { get; set; }

        public override string Serialize()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
