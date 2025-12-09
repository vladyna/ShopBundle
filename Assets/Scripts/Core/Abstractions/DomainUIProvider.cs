using System;

namespace Core.Abstractions
{
    public abstract class DomainUIProvider<T> : IDomainUIProvider
    {
        public DomainController<T> Controller { get; protected set; }
        public ValueKey<T> Key { get; protected set; }
        public event Action OnValueChanged;

        public virtual string DisplayName => Key.DisplayName;

        public DomainUIProvider(DomainController<T> controller, ValueKey<T> key)
        {
            Controller = controller;
            Key = key;
            Controller.OnValueChanged += () => OnValueChanged?.Invoke();
            Controller.SetDefaultValue(key);
        }

        public virtual string GetDisplayValue()
        {
            return Controller.GetCurrentValue(Key).ToString();
        }
        public abstract void IncrementValue();
    }
}
