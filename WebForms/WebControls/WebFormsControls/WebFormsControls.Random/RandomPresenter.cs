using System;

using WebFormsMvp;

namespace WebFormsControls.RandomNumber
{
    public class RandomPresenter : Presenter<IRandomView>
    {
        private readonly IRandomView view;
        private readonly Random random;

        public RandomPresenter(IRandomView view, Random random)
            : base(view)
        {
            this.view = view;
            this.view.Generate += this.OnGenerateRandomNumber;

            this.random = random;
        }

        private void OnGenerateRandomNumber(object sender, RandomEventArgs args)
        {
            try
            {
                var minimumValue = int.Parse(args.MinimumValue);
                var maximumValue = int.Parse(args.MaximumValue);
                if (maximumValue < minimumValue)
                {
                    minimumValue ^= maximumValue;
                    maximumValue ^= minimumValue;
                    minimumValue ^= maximumValue;
                }

                var randomNumber = this.random.Next(minimumValue, maximumValue);

                this.view.Model.RandomValue = randomNumber.ToString();
            }
            catch (Exception)
            {
                this.view.Model.RandomValue = "Naughty!";
            }
        }
    }
}
