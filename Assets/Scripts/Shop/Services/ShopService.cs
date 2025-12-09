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
            InitializeBundleShopUI();
            PlayerData.Instance.OnDataChanged += OnStatsUpdated;
        }

        private void OnDestroy()
        {
            PlayerData.Instance.OnDataChanged -= OnStatsUpdated;
        }

        private void InitializeBundleShopUI()
        {
            foreach (var bundle in _bundles)
            {
                var bundleCardView = Instantiate(_bundleCardViewPrefab);
                bundleCardView.OnBuyButtonClicked += OnBuyButtonClicked;
                bundleCardView.OnBuyButtonUpdate += OnBuyButtonUpdate;
                bundleCardView.OnInfoButtonClicked += OnInfoButtonClicked;
                bundleCardView.Setup(bundle);
                _bundleShopView.AddBundleViewCard(bundleCardView);
            }
        }

        private void OnBuyButtonClicked(BundleSO b, System.Action onComplete)
        {
            var bundle = b;
            var onCompleteAction = onComplete;
            ServerService.Instance.SendRequest((success =>
            {
                if (success && _shopController.CanPurchase(bundle))
                {
                    _shopController.Purchase(bundle, onCompleteAction);
                }
                else
                {
                    onCompleteAction?.Invoke();
                }
            }));
        }

        private void OnBuyButtonUpdate(BundleSO b, System.Action<bool> onComplete)
        {
            onComplete?.Invoke(_shopController.CanPurchase(b));
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
