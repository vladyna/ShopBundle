using System;

namespace Core.Abstractions
{
    public interface IDomainUIProvider
    {
        event Action OnValueChanged;
        string DisplayName { get; }
        string GetDisplayValue();
        void IncrementValue();
    }
}
