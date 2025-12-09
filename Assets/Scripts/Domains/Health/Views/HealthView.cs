using Core.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Gold.Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _healthAmountText;
        [SerializeField] private Button _addHealthButton;
    
        private IDomainUIProvider _provider;
    
        public void Initialize(IDomainUIProvider provider)
        {
            _provider = provider;
            _provider.OnValueChanged += UpdateView;
            _addHealthButton.onClick.AddListener(_provider.IncrementValue);
            UpdateView();
        }
    
        private void UpdateView()
        {
            _healthText.text = _provider.DisplayName;
            _healthAmountText.text = _provider.GetDisplayValue();
        }
    }
}
