using UnityEngine;

namespace Core.Abstractions
{
    public abstract class ValueKey<T> : ScriptableObject
    {
        [SerializeField] protected string _displayName;
        [SerializeField] protected T _defaultValue;
        public virtual string DisplayName => _displayName;
        public virtual T DefaultValue => _defaultValue;
    }
}