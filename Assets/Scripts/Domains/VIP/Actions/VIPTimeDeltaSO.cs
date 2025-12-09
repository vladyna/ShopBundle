using Core.Abstractions;
using Domains.VIP.Controllers;
using System;
using UnityEngine;

namespace Domains.VIP.Actions
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/VIP/VIPTimeDelta", fileName = "VIPTimeDelta")]
    public class VIPTimeDeltaSO : BundleActionSO<double>
    {
        public override Type DomainControllerType => typeof(VIPController);
    }
}
