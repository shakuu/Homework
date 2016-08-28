using System;

using Task1.ClassChef.Contracts;

namespace Task1.ClassChef
{
    public class Chef : IChef
    {
        public IMeal Cook(IOven oven)
        {
            var potato = this.GetPotato();
            var carrot = this.GetCarrot();

            var peeledPotato = this.Peel(potato);
            var peeledCarrot = this.Peel(carrot);

            var cutPotato = this.Cut(peeledPotato);
            var curCarrot = this.Cut(peeledCarrot);

            var bowl = this.GetBowl();
            var bowlWithVegetables = bowl.Add(curCarrot).Add(cutPotato);

            var preparedMeal = oven.Cook(bowlWithVegetables);
            return preparedMeal;
        }

        private IVegetable Cut(IVegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private IVegetable Peel(IVegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private IPotato GetPotato()
        {
            throw new NotImplementedException();
        }

        private ICarrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private IBowl GetBowl()
        {
            throw new NotImplementedException();
        }
    }
}
