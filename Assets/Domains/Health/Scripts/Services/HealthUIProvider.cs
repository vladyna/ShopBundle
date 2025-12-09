using Core.Abstractions;
using Domains.Health.Controllers;

namespace Domains.Health.Services
{
    public class HealthUIProvider : DomainUIProvider<int>
    {
        public HealthUIProvider(HealthController controller, HealthKey healthKey) : base(controller, healthKey)
        {

        }

        public override void IncrementValue()
        {
            ((HealthController)Controller).ModifyHealth(10);
        }
    }
}
