using UnityEngine;
using MyGame.Game.Transport;
using MyGame.Profile;

namespace MyGame
{
    [CreateAssetMenu(fileName = nameof(GeneralSettings), menuName = "Configs/Settings/" + nameof(GeneralSettings))]
    internal class GeneralSettings : ScriptableObject
    {
        [field: SerializeField] public float SpeedCar = 15f;
        [field: SerializeField] public GameState InitiialState = GameState.Start;
        [field: SerializeField] public TransportType carType = TransportType.SpeedCar;
    }
}
