using Core.Abstractions;
using Domains.Gold.Controllers;
using Domains.Gold.Models;
using Domains.Gold.Views;
using UnityEngine;

namespace Domains.Gold.Services
{
    public class GoldDomainProvider : DomainProvider
    {
        [SerializeField] private GoldView _goldView; 
        [SerializeField] private GoldKey _goldKey; 

        private void Start()
        {
            Initialize();
        }
        public override void Initialize()
        {
            if (Controller != null || UIProvider != null)
                return;

            Controller = new GoldController(_goldKey);
            UIProvider = new GoldUIProvider((GoldController)Controller, _goldKey);

            _goldView.Initialize(UIProvider);
        }
    }
}
