using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Tools
{
    internal interface IReadonlySubscriptionProperty<out TValue>
    {
        TValue Value { get; }

        void SubscribeOnChange(Action<TValue> subscriptionAction);
        void UnSubscribeOnChange(Action<TValue> unSubscriptionAction);
    }
}
