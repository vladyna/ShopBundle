using Core.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domains.VIP.Views
{
    public class VIPView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _vipText;
        [SerializeField] private TextMeshProUGUI _vipAmountText;
        [SerializeField] private Button _addVIPButton;

        private IDomainUIProvider _provider;

        public void Initialize(IDomainUIProvider provider)
        {
            _provider = provider;
            _provider.OnValueChanged += UpdateView;
            _addVIPButton.onClick.AddListener(_provider.IncrementValue);
            UpdateView();
        }

        private void UpdateView()
        {
            _vipText.text = _provider.DisplayName;
            _vipAmountText.text = _provider.GetDisplayValue();
        }
    }
}
