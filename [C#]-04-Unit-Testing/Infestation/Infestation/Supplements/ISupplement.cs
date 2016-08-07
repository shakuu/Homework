namespace Infestation
{
    public interface ISupplement
    {
        void ReactTo(ISupplement otherSupplement);
        int PowerEffect { get; }
        int HealthEffect { get; }
        int AggressionEffect { get; }
    }
}
