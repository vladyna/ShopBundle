using Core.Abstractions;
using Domains.Gold.Views;
using Domains.Health.Controllers;
using UnityEngine;

namespace Domains.Health.Services
{
    public class HealthDomainProvider : DomainProvider
    {
        [SerializeField] private HealthView _healthView;
        [SerializeField] private HealthKey _healthKey;

        private void Start()
        {
            Initialize();
        }

        public override void Initialize()
        {
            if (Controller != null || UIProvider != null)
                return;

            Controller = new HealthController(_healthKey);
            UIProvider = new HealthUIProvider((HealthController)Controller, _healthKey);

            _healthView.Initialize(UIProvider);
        }
    }
}
