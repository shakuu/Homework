using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.DecisionMakers
{
    public class MidlevelDecisionMaker : DecisionMaker
    {
        public override void MakeDecision(DecisionSeverityType decisionSeverity)
        {
            if (decisionSeverity == DecisionSeverityType.Medium)
            {
                // Class is competent.
            }
            else if (this.superiorDecisionMaker != null)
            {
                this.superiorDecisionMaker.MakeDecision(decisionSeverity);
            }
        }
    }
}
