using MyGame.Profile;
using MyGame.Tools;
using MyGame.Game.Transport;
using System;
using UnityEngine;

namespace MyGame.Game.InputLogic
{
    internal class InputGameController : BaseController
    {
        private readonly ResourcePath path = new ResourcePath("Prefabs/InputLogic/Keyboard");
        private BaseInputView inputView;

        public InputGameController(
            SubscriptionProperty<float> leftMoveDiff,
            SubscriptionProperty<float> rightMoveDif,
            TransportModel transportModel)
        {
            inputView = LoadVier();
            inputView.Init(leftMoveDiff, rightMoveDif, transportModel.Speed);
        }

        private BaseInputView LoadVier()
        {
            GameObject prefab = ResourceLoader.LoadPref(path);
            GameObject inputView = GameObject.Instantiate(prefab);

            AddGameObject(inputView);

            return inputView.GetComponent<BaseInputView>();
        }
    }
}