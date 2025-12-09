using UnityEngine;

namespace Core.Abstractions
{
    public abstract class BundleAction : ScriptableObject
    {
        public abstract System.Type DomainControllerType { get; }
    }
}