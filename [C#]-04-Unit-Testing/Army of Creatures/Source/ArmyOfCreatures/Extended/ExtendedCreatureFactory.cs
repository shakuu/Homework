namespace ArmyOfCreatures.Extended
{
    using System;

    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Creatures;

    internal class ExtendedCreaturesFactory : CreaturesFactory
    {
        public override Creature CreateCreature(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Creature Name is null or empty");
            }

            switch (name)
            {
                case "AncientBehemoth":
                    return new AncientBehemoth();
                case "CyclopsKing":
                    return new CyclopsKing();
                case "Goblin":
                    return new Goblin();
                case "Griffin":
                    return new Griffin();
                case "WolfRaider":
                    return new WolfRaider();
                default:
                    return base.CreateCreature(name);
            }
        }
    }
}
