using Core.Abstractions;
using Core.PlayerData;
using Domains.Health.Actions;

namespace Domains.Health.Controllers
{
    public class HealthController : DomainController<int>
    {
        public HealthController(HealthKey healthKey)
        {
            _key = healthKey;
        }

        public void ModifyHealth(int delta)
        {
            PlayerData.Instance.Modify(_key, x => x + delta);
            FireValueChanged();
        }

        public override bool CanApply(BundleAction action)
        {
            if (action is HealthDeltaSO gAction)
            {
                int current = PlayerData.Instance.Get(_key);
                return current >= gAction.Value;
            }
            return false;
        }

        public override void ApplyPrice(BundleAction action)
        {
            if (action is HealthDeltaSO gAction)
                ModifyHealth(-gAction.Value);
        }

        public override void ApplyReward(BundleAction action)
        {
            if (action is HealthDeltaSO gAction)
                ModifyHealth(gAction.Value);
        }
    }
}
