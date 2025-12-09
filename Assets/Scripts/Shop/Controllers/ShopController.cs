using System;
using System.Collections.Generic;
using UnityEngine;
using Core.Abstractions;

namespace Shop.Controllers
{
    public class ShopController 
    {
        private DomainProvider[] _domainProviders;

        private Dictionary<Type, IDomainController> _controllers = new();

        public ShopController(DomainProvider[] domainProviders)
        {
            _domainProviders = domainProviders;
            RegisterProvider(); 
        }

        private void RegisterProvider()
        {
            foreach (var provider in _domainProviders)
            {
                provider.Initialize();
                _controllers[provider.Controller.GetType()] = provider.Controller;
            }
        }

        private IDomainController ResolveController(BundleAction action)
        {
            if (_controllers.TryGetValue(action.DomainControllerType, out var controller))
                return controller;

            Debug.LogError($"Не найден контроллер: {action.DomainControllerType}");
            return null;
        }

        public bool CanPurchase(BundleSO bundle)
        {
            foreach (var action in bundle.CostActions)
                if (!ResolveController(action).CanApply(action))
                    return false;
            return true;
        }

        public void Purchase(BundleSO bundle, Action onComplete)
        {
            // NOTE(): Implement a server service call here for real purchases
            ProcessPurchase(bundle, onComplete);
        }

        private void ProcessPurchase(BundleSO bundle, Action onComplete)
        {
            foreach (var action in bundle.CostActions)
                ResolveController(action).ApplyPrice(action);


            foreach (var action in bundle.RewardActions)
                ResolveController(action).ApplyReward(action);

            onComplete?.Invoke();
        }
    }
}
