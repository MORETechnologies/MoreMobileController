namespace MoreMobileController.Core
{
    public class MotorComponentViewModel
    {
        const string ComponentType = "motor";
        const string AddCommand = "add";
        const string ClockwiseCommand = "clockwise";
        const string CounterclockwiseCommand = "counter";
        const string RemoveCommand = "remove";

        private static int motorCount;

        int id;
        IBotClient client;

        internal MotorComponentViewModel(IBotClient client)
        {
            this.client = client;
            id = motorCount;
            motorCount++;

            Speed = 100;
        }

        public int SpeedPin { get; set; }

        public int DirectionPin1 { get; set; }

        public int DirectionPin2 { get; set; }

        public int Speed { get; set; }

        public void AddMotor()
        {
            MotorMessage message = new MotorMessage();
            message.Id = id;
            message.Command = AddCommand;
            message.SpeedPin = SpeedPin;
            message.DirectionPin1 = DirectionPin1;
            message.DirectionPin2 = DirectionPin2;

            client.SendMessage(WrapMotorMessage(message));
        }

        public void RemoveMotor()
        {
            MotorMessage message = new MotorMessage();
            message.Id = id;
            message.Command = RemoveCommand;

            client.SendMessage(WrapMotorMessage(message));
        }

        public void RotateClockwise()
        {
            MotorMessage message = new MotorMessage();
            message.Id = id;
            message.Command = ClockwiseCommand;
            message.Data = Speed.ToString();

            client.SendMessage(WrapMotorMessage(message));
        }

        public void RotateCounterclockwise()
        {
            MotorMessage message = new MotorMessage();
            message.Id = id;
            message.Command = CounterclockwiseCommand;
            message.Data = Speed.ToString();

            client.SendMessage(WrapMotorMessage(message));
        }

        private static BotMessage WrapMotorMessage(MotorMessage message)
        {
            BotMessage wrapper = new BotMessage();
            wrapper.Command = ComponentType;
            wrapper.Data = message.Serialize();

            return wrapper;
        }
    }
}
