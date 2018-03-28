using Newtonsoft.Json;
using System.Text;


namespace MoreMobileController.Core
{
    public class BotMessage
    {
        public static BotMessage Deserialize(byte[] data)
        {
            string json = Encoding.UTF8.GetString(data);

            return JsonConvert.DeserializeObject<BotMessage>(json);
        }

        public string Command { get; set; }

        public string Data { get; set; }

        public byte[] Serialize()
        {
            string json = JsonConvert.SerializeObject(this);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}
