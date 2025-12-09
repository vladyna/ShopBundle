using Core.Abstractions;
using Domains.Location.Controllers;
using Domains.Location.Models;
using Domains.Location.Views;
using UnityEngine;

namespace Domains.Gold.Services
{
    public class LocationDomainProvider : DomainProvider
    {
        [SerializeField] private LocationView _locationView;
        [SerializeField] private LocationKey _locationKey;

        private void Start()
        {
            Initialize();
        }

        public override void Initialize()
        {
            if (Controller != null || UIProvider != null)
                return;

            Controller = new LocationController(_locationKey);
            UIProvider = new LocationUIProvider((LocationController)Controller, _locationKey);

            _locationView.Initialize(UIProvider);
        }
    }
}
