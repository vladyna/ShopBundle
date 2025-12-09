using Core.Abstractions;
using Core.PlayerData;
using Domains.VIP.Actions;
using Domains.VIP.Models;
using System;

namespace Domains.VIP.Controllers
{
    public class VIPController : DomainController<TimeSpan>
    {
        public VIPController(VIPKey vipKey)
        {
            _key = vipKey;

        }

        public void ModifyVIPTime(TimeSpan delta)
        {
            PlayerData.Instance.Modify(_key, x => x + delta);
            FireValueChanged();
        }

        public override bool CanApply(BundleAction action)
        {
            if (action is VIPTimeDeltaSO gAction)
            {
                var current = PlayerData.Instance.Get(_key);
                return current >= TimeSpan.FromSeconds(gAction.Value);
            }
            return false;
        }

        public override void ApplyPrice(BundleAction action)
        {
            if (action is VIPTimeDeltaSO gAction)
                ModifyVIPTime(-TimeSpan.FromSeconds(gAction.Value));
        }

        public override void ApplyReward(BundleAction action)
        {
            if (action is VIPTimeDeltaSO gAction)
                ModifyVIPTime(TimeSpan.FromSeconds(gAction.Value));
        }
    }
}
