using System.Collections.Generic;
using UnityEngine;

namespace Shop.Views
{
    public class BundleShopView : MonoBehaviour
    {
        [SerializeField] private Transform _bundleCardContainer;
        private List<BundleCardView> _bundleCardViews = new();

        public IReadOnlyList<BundleCardView> BundleCardViews => _bundleCardViews;

        public void AddBundleViewCard(BundleCardView bundleCardView)
        {
            _bundleCardViews.Add(bundleCardView);
            bundleCardView.transform.SetParent(_bundleCardContainer, false);
        }
    }
}
