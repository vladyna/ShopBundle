using Core.Abstractions;
using Domains.Location.Controllers;
using Domains.Location.Models;
namespace Domains.Gold.Services
{
    public class LocationUIProvider : DomainUIProvider<string>
    {
        public LocationUIProvider(LocationController controller, LocationKey locationKey) : base(controller, locationKey)
        {
        }

        public override void IncrementValue()
        {
            ((LocationController)Controller).ModifyLocation("Поле");
        }
    }
}
