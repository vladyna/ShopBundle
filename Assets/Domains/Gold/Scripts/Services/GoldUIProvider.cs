using Core.Abstractions;
using Domains.Gold.Controllers;
using Domains.Gold.Models;

namespace Domains.Gold.Services
{
    public class GoldUIProvider : DomainUIProvider<int>
    {
        public GoldUIProvider(GoldController controller, GoldKey goldKey) : base(controller, goldKey)
        {
        }

        public override void IncrementValue()
        {
            ((GoldController)Controller).ModifyGold(10);
        }
    }
}
