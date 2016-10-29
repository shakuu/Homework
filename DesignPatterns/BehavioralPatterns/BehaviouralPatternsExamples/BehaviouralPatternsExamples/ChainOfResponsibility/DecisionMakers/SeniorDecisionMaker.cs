using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.DecisionMakers
{
    public class SeniorDecisionMaker : DecisionMaker
    {
        public override void MakeDecision(DecisionSeverityType decisionSeverity)
        {
            if (decisionSeverity == DecisionSeverityType.High)
            {
                // Class is competent
            }
            else if (this.superiorDecisionMaker != null)
            {
                this.superiorDecisionMaker.MakeDecision(decisionSeverity);
            }
        }
    }
}
