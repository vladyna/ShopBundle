using Shop.Controllers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

namespace Shop.Views
{
    public class BundleCardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bundleNameText;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _infoButton;

        private BundleSO _bundle;

        public event Action<BundleSO, Action> OnBuyButtonClicked;
        public event Action<BundleSO> OnInfoButtonClicked;
        public event Action<BundleSO, Action<bool>> OnBuyButtonUpdate;

        public void Setup(BundleSO bundle, bool isDetail = false)
        {
            this._bundle = bundle;
            _bundleNameText.text = bundle.BundleName;
            UpdateBuyButton();
            InitializeBuyButton();
            InitializeInfoButton(isDetail);
        }

        public void UpdateBuyButton()
        {
            OnBuyButtonUpdate?.Invoke(_bundle, (canPurchase) =>
            {
                _buyButton.interactable = canPurchase;
            });
        }

        private void InitializeBuyButton()
        {
            _buyButton.onClick.AddListener(() =>
            {
                _buyButton.interactable = false;
                _buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Обработка...";
                OnBuyButtonClicked.Invoke(_bundle, () =>
                {
                    _buyButton.interactable = true;
                    _buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Купить";
                    UpdateBuyButton();
                });
            });
        }

        private void InitializeInfoButton(bool isDetail)
        {
            if(isDetail)
            {
                _infoButton.gameObject.SetActive(false);
            }
            else
            {
                _infoButton.onClick.AddListener(() =>
                {
                    _infoButton.interactable = false;
                    OnInfoButtonClicked?.Invoke(_bundle);
                });
            }
        }
    }
}
