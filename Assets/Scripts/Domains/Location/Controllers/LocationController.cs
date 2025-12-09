using Core.Abstractions;
using Core.PlayerData;
using Domains.Location.Actions;
using Domains.Location.Models;

namespace Domains.Location.Controllers
{
    public class LocationController : DomainController<string>
    {
        public LocationController(LocationKey locationKey)
        {
            _key = locationKey;
        }

        public void ModifyLocation(string location)
        {
            PlayerData.Instance.Modify(_key, x => location);
            FireValueChanged();
        }

        public override bool CanApply(BundleAction action)
        {
            return true;
        }

        public override void ApplyPrice(BundleAction action)
        {
            if (action is SetLocationSO gAction)
                ModifyLocation(gAction.Value);
        }

        public override void ApplyReward(BundleAction action)
        {
            if (action is SetLocationSO gAction)
                ModifyLocation(gAction.Value);
        }
    }
}
