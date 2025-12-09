using Core.Abstractions;
using Domains.VIP.Controllers;
using Domains.VIP.Models;
using System;

namespace Domains.VIP.Services
{
    public class VIPUIProvider : DomainUIProvider<TimeSpan>
    {
        public VIPUIProvider(VIPController controller, VIPKey goldKey) : base(controller, goldKey)
        {
        }

        public override void IncrementValue()
        {
            ((VIPController)Controller).ModifyVIPTime(new TimeSpan(0, 0, 10));
        }
    }
}
