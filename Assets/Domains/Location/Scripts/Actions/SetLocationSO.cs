using Core.Abstractions;
using Domains.Location.Controllers;
using System;
using UnityEngine;

namespace Domains.Location.Actions
{
    [CreateAssetMenu(menuName = "BundleShop/Domains/Location/SetLocation", fileName = "SetLocation")]
    public class SetLocationSO : BundleActionSO<string>
    {
        public override Type DomainControllerType => typeof(LocationController);
    }
}
