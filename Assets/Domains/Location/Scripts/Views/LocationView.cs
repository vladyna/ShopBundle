using Core.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.Location.Views
{
    public class LocationView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _locationText;
        [SerializeField] private TextMeshProUGUI _locationAmountText;
        [SerializeField] private Button _addLocationButton;

        private IDomainUIProvider _provider;

        public void Initialize(IDomainUIProvider provider)
        {
            _provider = provider;
            _provider.OnValueChanged += UpdateView;
            _addLocationButton.onClick.AddListener(_provider.IncrementValue);
            UpdateView();
        }

        private void UpdateView()
        {
            _locationText.text = $"{_provider.DisplayName}:";
            _locationAmountText.text = _provider.GetDisplayValue();
        }
    }
}
