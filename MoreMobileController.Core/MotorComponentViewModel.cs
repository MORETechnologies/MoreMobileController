using System.Threading.Tasks;

namespace MoreMobileController.Core
{
    public class MotorComponentViewModel
    {
        IBotClient client;

        internal MotorComponentViewModel(IBotClient client)
        {
            this.client = client;

            Speed = 100;
        }

        public byte SpeedPin { get; set; }

        public byte DirectionPin1 { get; set; }

        public byte DirectionPin2 { get; set; }

        public byte Speed { get; set; }

        public async Task AddMotor()
        {
            PinMessage message = new PinMessage();
            message.Command = PinMessage.OutputMode;
            message.PinNumber = SpeedPin;

            await client.SendMessage(WrapPinMessage(message));

            message.PinNumber = DirectionPin1;

            await client.SendMessage(WrapPinMessage(message));

            message.PinNumber = DirectionPin2;

            await client.SendMessage(WrapPinMessage(message));
        }

        public async Task RemoveMotor()
        {
            PinMessage message = new PinMessage();
            message.Command = PinMessage.AnalogWrite;
            message.PinNumber = SpeedPin;
            message.Data = "0";

            await client.SendMessage(WrapPinMessage(message));
        }

        public async Task RotateClockwise()
        {
            PinMessage message = new PinMessage();
            message.Command = PinMessage.WriteHigh;
            message.PinNumber = DirectionPin1;

            await client.SendMessage(WrapPinMessage(message));

            message.Command = PinMessage.WriteLow;
            message.PinNumber = DirectionPin2;

            await client.SendMessage(WrapPinMessage(message));

            message.Command = PinMessage.AnalogWrite;
            message.PinNumber = SpeedPin;
            message.Data = MapToRealValue(Speed).ToString();

            await client.SendMessage(WrapPinMessage(message));
        }

        public async Task RotateCounterclockwise()
        {
            PinMessage message = new PinMessage();
            message.Command = PinMessage.WriteLow;
            message.PinNumber = DirectionPin1;

            await client.SendMessage(WrapPinMessage(message));

            message.Command = PinMessage.WriteHigh;
            message.PinNumber = DirectionPin2;

            await client.SendMessage(WrapPinMessage(message));

            message.Command = PinMessage.AnalogWrite;
            message.PinNumber = SpeedPin;
            message.Data = MapToRealValue(Speed).ToString();

            await client.SendMessage(WrapPinMessage(message));
        }

        private static BotMessage WrapPinMessage(PinMessage message)
        {
            BotMessage wrapper = new BotMessage();
            wrapper.Command = PinMessage.CommandName;
            wrapper.Data = message.Serialize();

            return wrapper;
        }

        private static byte MapToRealValue(byte value)
        {
            return (byte)(255 * value / 100);
        }
    }
}
