using UnityEngine;

namespace Core.Abstractions
{
    public abstract class DomainProvider : MonoBehaviour
    {
        public virtual IDomainController Controller { get; protected set; }
        public virtual IDomainUIProvider UIProvider { get; protected set; }
        public abstract void Initialize();
    }
}