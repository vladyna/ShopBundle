using Core.Abstractions;
using UnityEngine;

namespace Domains.Gold.Models
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/Gold/GoldKey", fileName = "GoldKey")]
    public class GoldKey : ValueKey<int> { }
}