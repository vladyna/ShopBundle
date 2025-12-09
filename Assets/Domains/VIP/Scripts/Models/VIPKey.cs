using Core.Abstractions;
using System;
using UnityEngine;

namespace Domains.VIP.Models
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/VIP/VIPKey", fileName = "VIPKey")]
    public class VIPKey : ValueKey<TimeSpan> { }
}
