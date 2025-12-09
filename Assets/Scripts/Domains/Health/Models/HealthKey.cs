using Core.Abstractions;
using UnityEngine;

namespace Domains.Health
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/Health/HealthKey", fileName = "HealthKey")]
    public class HealthKey : ValueKey<int> { }
}
