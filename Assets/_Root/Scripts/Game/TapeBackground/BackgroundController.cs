using UnityEngine;
using MyGame.Tools;
using System;

namespace MyGame.Game.TapeBackground
{
    internal class BackgroundController : BaseController
    {
        private ResourcePath path = new ResourcePath("Prefabs/Background");

        private readonly IReadonlySubscriptionProperty<float> leftMove;
        private readonly IReadonlySubscriptionProperty<float> rightMove;
        private readonly SubscriptionProperty<float> diff;
        private readonly TapeBackground view;

        public BackgroundController(IReadonlySubscriptionProperty<float> leftMove, IReadonlySubscriptionProperty<float> rightMove)
        {
            diff = new SubscriptionProperty<float>();
            view = LoadView(path);
            view.Init(diff);

            this.leftMove = leftMove;
            this.rightMove = rightMove;

            leftMove.SubscribeOnChange(LeftMove);
            rightMove.SubscribeOnChange(RightMove);

        }
        private TapeBackground LoadView(ResourcePath path)
        {
            GameObject prefab = ResourceLoader.LoadPref(path);
            GameObject background = GameObject.Instantiate(prefab);
            AddGameObject(background);
            return background.GetComponent<TapeBackground>();

        }

        private void LeftMove(float value)
        {
            diff.Value = -value;
        }

        private void RightMove(float value)
        {
            diff.Value = value;
        }
        protected override void OnDispose()
        {
            leftMove.UnSubscribeOnChange(LeftMove);
            rightMove.UnSubscribeOnChange(RightMove);
        }


    }
}
