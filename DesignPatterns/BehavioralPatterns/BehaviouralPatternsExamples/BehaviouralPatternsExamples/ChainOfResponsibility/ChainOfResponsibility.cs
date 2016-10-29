using ChainOfResponsibility.DecisionMakers;

namespace ChainOfResponsibility
{
    public class ChainOfResponsibility
    {
        public static void Main()
        {
            // Define the chain of responsibility.
            var junior = new JuniorDecisionMaker();
            var midlevel = new MidlevelDecisionMaker();
            var senior = new SeniorDecisionMaker();

            junior.AssignSuperiorDecisionMaker(midlevel);
            midlevel.AssignSuperiorDecisionMaker(senior);

            // Make a decision.
            junior.MakeDecision(Enums.DecisionSeverityType.High);
        }
    }
}
