using Core.Abstractions;
using Domains.VIP.Controllers;
using Domains.VIP.Models;
using Domains.VIP.Views;
using UnityEngine;

namespace Domains.VIP.Services
{
    public class VIPDomainProvider : DomainProvider
    {
        [SerializeField] private VIPView _vipView;
        [SerializeField] private VIPKey _vipKey;

        private void Start()
        {
            Initialize();
        }

        public override void Initialize()
        {
            if (Controller != null || UIProvider != null)
                return;

            Controller = new VIPController(_vipKey);
            UIProvider = new VIPUIProvider((VIPController)Controller, _vipKey);

            _vipView.Initialize(UIProvider);
        }
    }
}
