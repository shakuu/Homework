using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.DecisionMakers
{
    public class JuniorDecisionMaker : DecisionMaker
    {
        public override void MakeDecision(DecisionSeverityType decisionSeverity)
        {
            if (decisionSeverity == DecisionSeverityType.Low)
            {
                // Class is competent enough to do the work. 
            }
            else if (this.superiorDecisionMaker != null)
            {
                // Pass the request to next DecisionMaker in the chain.
                this.superiorDecisionMaker.MakeDecision(decisionSeverity);
            }
        }
    }
}
