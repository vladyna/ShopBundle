using Core.Players;
using System;

namespace Core.Abstractions
{
    public abstract class DomainController<T> : IDomainController
    {
        protected ValueKey<T> _key;

        protected PlayerData playerData => PlayerData.Instance;

        public ValueKey<T> Key => _key;
        public event Action OnValueChanged;

        protected void FireValueChanged()
        {
            OnValueChanged?.Invoke();
        }

        public abstract bool CanApply(BundleAction action);
        public abstract void ApplyPrice(BundleAction action);
        public abstract void ApplyReward(BundleAction action);

        public virtual void SetDefaultValue(ValueKey<T> key)
        {
            if (!playerData.Contains(key))
            {
                playerData.Set(key, key.DefaultValue);
            }
        }

        public virtual T GetCurrentValue()
        {
            if (playerData.Contains(_key))
            {
                return playerData.Get(_key);
            }
            return default;
        }
    }
}
