using Core.Abstractions;
using Domains.Health.Controllers;
using System;
using UnityEngine;

namespace Domains.Health.Actions
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/Health/HealthDelta", fileName = "HealthDelta")]
    public class HealthDeltaSO : BundleActionSO<int>
    {
        public override Type DomainControllerType => typeof(HealthController);
    }
}
