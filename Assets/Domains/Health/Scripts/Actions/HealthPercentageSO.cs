using Core.Abstractions;
using Domains.Health.Controllers;
using System;
using UnityEngine;

namespace Domains.Health.Actions
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/Health/HealthPercentage", fileName = "HealthPercentage")]
    public class HealthPercentageSO : BundleActionSO<int>
    {
        public override Type DomainControllerType => typeof(HealthController);
    }
}
