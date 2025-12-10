using Core.Abstractions;
using Core.Players;
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
            if (action is HealthPercentageSO)
                return true;
            return false;
        }

        public override void ApplyPrice(BundleAction action)
        {
            ModifyHealth(-GetActionValue(action));
        }

        public override void ApplyReward(BundleAction action)
        {
            ModifyHealth(GetActionValue(action));
        }

        private int GetActionValue(BundleAction action)
        {
            int value = 0;
            if (action is HealthDeltaSO gAction)
                value = gAction.Value;
            if (action is HealthPercentageSO pAction)
            {
                int current = GetCurrentValue();
                value = (current * pAction.Value / 100);
            }
            return value;
        }
    }
}
