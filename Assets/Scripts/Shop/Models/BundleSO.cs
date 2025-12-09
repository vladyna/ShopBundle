using Core.Abstractions;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "BundleShop/Shop/Bundle")]
    public class BundleSO : ScriptableObject
    {
        public string BundleName;
        public BundleAction[] CostActions;
        public BundleAction[] RewardActions;
    }
}
