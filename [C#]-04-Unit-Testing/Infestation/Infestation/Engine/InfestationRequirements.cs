
namespace Infestation
{
    using System;

    public static class InfestationRequirements
    {
        public static UnitClassification RequiredClassificationToInfest(UnitClassification targetUnit)
        {
            switch (targetUnit)
            {
                case UnitClassification.Biological:
                    return UnitClassification.Biological;
                    
                case UnitClassification.Mechanical:
                    return UnitClassification.Psionic;
                    
                case UnitClassification.Psionic:
                    return UnitClassification.Psionic;
                    
                default:
                    throw new InvalidOperationException("Unknown unit classification: " + targetUnit);
            }
        }
    }
}
