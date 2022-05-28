using MyGame.Features.Shed.Upgrade;

namespace MyGame.Profile
{
    internal class CarModel : IUpgradable
    {
        private float defaultSpeed;
        public float Speed { get; set; }
        public CarModel(float speed)
        {
            defaultSpeed = speed;
            Speed = speed;
        }

        public void Restor()
        {
            Speed = defaultSpeed;
        }
    }
}