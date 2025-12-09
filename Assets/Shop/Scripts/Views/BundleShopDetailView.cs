using System;
using UnityEngine;
using UnityEngine.UI;
namespace Shop.Views
{
    public class BundleShopDetailView : MonoBehaviour
    {
        [SerializeField] private Button _backButton;

        public event Action OnBackButtonClicked;

        private void Awake()
        {
            _backButton.onClick.AddListener(HandleBackButtonClicked);
        }

        private void OnDestroy()
        {
            _backButton.onClick.RemoveListener(HandleBackButtonClicked);
        }

        private void HandleBackButtonClicked()
        {
            OnBackButtonClicked?.Invoke();
        }
    }
}
