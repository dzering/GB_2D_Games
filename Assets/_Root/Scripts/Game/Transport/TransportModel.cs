using MyGame.Features.Shed.Upgrade;
using MyGame.Game.Transport;

namespace MyGame.Game.Transport
{
    internal class TransportModel : IUpgradable
    {
        private readonly float defaultSpeed;

        public readonly TransportType TransportType;
        public float Speed { get; set; }
        public TransportModel(float speed, TransportType type)
        {
            defaultSpeed = speed;
            Speed = speed;
            TransportType = type;
        }

        public void Restor()
        {
            Speed = defaultSpeed;
        }
    }
}