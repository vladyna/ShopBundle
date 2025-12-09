using Core.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Gold.Views
{
    public class GoldView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private TextMeshProUGUI _goldAmountText;
        [SerializeField] private Button _addGoldButton;

        private IDomainUIProvider _provider;

        public void Initialize(IDomainUIProvider provider)
        {
            _provider = provider;
            _provider.OnValueChanged += UpdateView;
            _addGoldButton.onClick.AddListener(_provider.IncrementValue);
            UpdateView();
        }

        private void UpdateView()
        {
            _goldText.text = $"{_provider.DisplayName}:";
            _goldAmountText.text = _provider.GetDisplayValue();
        }
    }
}
