using Core.Abstractions;
using Domains.Gold.Controllers;
using System;
using UnityEngine;

namespace Domains.Gold.Actions
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/Gold/GoldDelta", fileName = "GoldDelta")]
    public class GoldDeltaSO : BundleActionSO<int>
    {
        public override Type DomainControllerType => typeof(GoldController);
    }
}
