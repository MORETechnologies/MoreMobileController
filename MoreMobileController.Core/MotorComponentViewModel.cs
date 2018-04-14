namespace MoreMobileController.Core
{
    public class MotorComponentViewModel
    {
        const string AddCommand = "motor-add";
        const string ClockwiseCommand = "motor-clockwise";
        const string CounterclockwiseCommand = "motor-counter";
        const string RemoveCommand = "motor-remove";

        private static int motorCount;

        int id;
        IBotClient client;

        internal MotorComponentViewModel(IBotClient client)
        {
            this.client = client;
            id = motorCount;
            motorCount++;
        }

        public int SpeedPin { get; set; }

        public int DirectionPin1 { get; set; }

        public int DirectionPin2 { get; set; }

        public void AddMotor()
        {
            BotMessage message = new BotMessage();
            message.Id = id;
            message.Command = AddCommand;
            message.Pins = new[] { SpeedPin, DirectionPin1, DirectionPin2 };

            client.SendMessage(message);
        }

        public void RemoveMotor()
        {
            BotMessage message = new BotMessage();
            message.Id = id;
            message.Command = RemoveCommand;

            client.SendMessage(message);
        }

        public void RotateClockwise()
        {
            BotMessage message = new BotMessage();
            message.Id = id;
            message.Command = ClockwiseCommand;

            client.SendMessage(message);
        }

        public void RotateCounterclockwise()
        {
            BotMessage message = new BotMessage();
            message.Id = id;
            message.Command = CounterclockwiseCommand;

            client.SendMessage(message);
        }
    }
}
