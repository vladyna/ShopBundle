using Core.Abstractions;
using Core.Data;
using Core.PlayerData;
using Core.Services;
using Shop.Controllers;
using Shop.Views;
using UnityEngine;
namespace Shop.Services
{
    public class ShopService : MonoBehaviour
    {
        [SerializeField] private BundleShopView _bundleShopView;
        [SerializeField] private BundleCardView _bundleCardViewPrefab;
        [SerializeField] private SceneObject _cardDetailsScene;
        [SerializeField] private DomainProvider[] _domainProviders;
        [SerializeField] private BundleSO[] _bundles;

        private ShopController _shopController;

        private void Start()
        {
            _shopController = new ShopController(_domainProviders);
            IntializeBundleShopUI();
            PlayerData.Instance.OnDataChanged += OnStatsUpdated;
        }

        private void OnDestroy()
        {
            PlayerData.Instance.OnDataChanged -= OnStatsUpdated;
        }

        private void IntializeBundleShopUI()
        {
            foreach (var bundle in _bundles)
            {
                var bundleCardView = Instantiate(_bundleCardViewPrefab);
                bundleCardView.Setup(bundle);
                bundleCardView.OnBuyButtonClicked += (b, onComplete) =>
                {
                    _shopController.Purchase(b, onComplete);
                };
                bundleCardView.OnBuyButtonUpdate += (b, onComplete) =>
                {
                    onComplete.Invoke(_shopController.CanPurchase(b));
                };
                bundleCardView.OnInfoButtonClicked += OnInfoButtonClicked;
                _bundleShopView.AddBundleViewCard(bundleCardView);
            }
        }

        private void OnInfoButtonClicked(BundleSO obj)
        {
            BundleNavigation.SelectedBundle = obj;
            SceneLoaderService.LoadScene(_cardDetailsScene);
        }

        private void OnStatsUpdated()
        {
            foreach (var bundleCardView in _bundleShopView.BundleCardViews)
            {
                bundleCardView.UpdateBuyButton();
            }
        }

    }
}
