using Core.Abstractions;
using UnityEngine;

namespace Domains.Location.Models
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/Location/LocationKey", fileName = "LocationKey")]
    public class LocationKey : ValueKey<string> { }
}