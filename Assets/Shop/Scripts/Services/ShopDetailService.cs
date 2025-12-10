using Core.Abstractions;
using Core.Data;
using Core.Players;
using Core.Services;
using Shop.Controllers;
using Shop.Views;
using UnityEngine;

namespace Shop.Services
{
    public class ShopDetailService : MonoBehaviour
    {
        [SerializeField] private BundleCardView _bundleCardView;
        [SerializeField] private BundleShopDetailView _bundleShopDetailView;
        [SerializeField] private SceneObject _shopScene;
        [SerializeField] private DomainProvider[] _domainProviders;
        private ShopController _shopController;

        private BundleCardView _currentBundleCardView;
        private void Start()
        {
            _shopController = new ShopController(_domainProviders);
            InitializeBundle();
            PlayerData.Instance.OnDataChanged += OnStatsUpdated;
            _bundleShopDetailView.OnBackButtonClicked += LoadMainScene;
        }

        private void OnDestroy()
        {
            PlayerData.Instance.OnDataChanged -= OnStatsUpdated;
            _bundleShopDetailView.OnBackButtonClicked -= LoadMainScene;
        }

        private void InitializeBundle()
        {
            if(BundleNavigation.SelectedBundle == null)
            {
                LoadMainScene();
                return;
            }
            var bundleCardView = _bundleCardView;
            _currentBundleCardView = bundleCardView;
            bundleCardView.OnBuyButtonClicked += OnBuyButtonClicked;
            bundleCardView.OnBuyButtonUpdate += OnBuyButtonUpdate;
            bundleCardView.Setup(BundleNavigation.SelectedBundle, true);
        }

        private void OnBuyButtonClicked(BundleSO b, System.Action onComplete)
        {
            ServerService.Instance.SendRequest((success =>
            {
                if (success && _shopController.CanPurchase(b))
                {
                    _shopController.Purchase(b, onComplete);
                }
                else
                {
                    onComplete?.Invoke();
                }
            }));
        }

        private void OnBuyButtonUpdate(BundleSO b, System.Action<bool> onComplete)
        {
            onComplete.Invoke(_shopController.CanPurchase(b));
        }

        private void OnStatsUpdated()
        {
            _currentBundleCardView.UpdateBuyButton();
        }

        private void LoadMainScene()
        {
            SceneLoaderService.LoadScene(_shopScene);
        }
    }
}
