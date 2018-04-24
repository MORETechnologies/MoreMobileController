using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoreMobileController.Core
{
    public class MotorMessage : BotMessage
    {
        public new static MotorMessage Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MotorMessage>(json);
        }

        public int Id { get; set; }

        public int SpeedPin { get; set; }

        public int DirectionPin1 { get; set; }

        public int DirectionPin2 { get; set; }

        public override string Serialize()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}
