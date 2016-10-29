using ChainOfResponsibility.Enums;

namespace ChainOfResponsibility.DecisionMakers
{
    public abstract class DecisionMaker
    {
        protected DecisionMaker superiorDecisionMaker;

        public void AssignSuperiorDecisionMaker(DecisionMaker superiorDecisionMaker)
        {
            this.superiorDecisionMaker = superiorDecisionMaker;
        }

        public abstract void MakeDecision(DecisionSeverityType decisionSeverity);
    }
}
