namespace Core.Abstractions
{
    public interface IDomainController
    {
        bool CanApply(BundleAction action);
        void ApplyReward(BundleAction action);
        void ApplyPrice(BundleAction action);
    }
}
