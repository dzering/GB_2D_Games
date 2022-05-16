using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Tools
{
    internal class SubscriptionProperty<T> : IReadonlySubscriptionProperty<T>
    {
        private T value;

        private Action<T> OnChange;

        public T Value 
        {
            get => this.value;
            set
            {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }

        public void SubscribeOnChange(Action<T> subscriptionAction)
        {
            OnChange += subscriptionAction;
        }

        public void UnSubscribeOnChange(Action<T> unSubscriptionAction)
        {
            OnChange -= unSubscriptionAction;
        }
    }
}
