using Core.Abstractions;
using Core.Players;
using Domains.Gold.Actions;
using Domains.Gold.Models;

namespace Domains.Gold.Controllers
{
    public class GoldController : DomainController<int>
    {
        public GoldController(GoldKey goldKey)
        {
            _key = goldKey;
        }

        public void ModifyGold(int delta)
        {
            PlayerData.Instance.Modify(_key, x => x + delta);
            FireValueChanged();
        }

        public override bool CanApply(BundleAction action)
        {
            if (action is GoldDeltaSO gAction)
            {
                int current = PlayerData.Instance.Get(_key);
                return current >= gAction.Value;
            }
            return false;
        }

        public override void ApplyPrice(BundleAction action)
        {
            if (action is GoldDeltaSO gAction)
                ModifyGold(-gAction.Value);
        }

        public override void ApplyReward(BundleAction action)
        {
            if (action is GoldDeltaSO gAction)
                ModifyGold(gAction.Value);
        }
    }
}
