
namespace MyGame.Features.Shed.Upgrade
{
    internal interface IUpgradable
    {
        float Speed { get; set; }
        void Restor();
    }
}
