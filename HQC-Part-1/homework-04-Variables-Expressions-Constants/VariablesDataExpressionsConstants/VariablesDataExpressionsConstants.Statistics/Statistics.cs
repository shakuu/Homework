using System;
using System.Collections.Generic;
using System.Linq;

using VariablesDataExpressionsConstants.Statistics.Contracts;

namespace VariablesDataExpressionsConstants.Statistics
{
    public class Statistic
    {
        private IWriter printer;

        public Statistic(IWriter printer)
        {
            this.printer = printer;
        }

        public void PrintStatistics(IEnumerable<double> data, int elementsToEvaluateCount)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            if (data.Count() == 0)
            {
                return;
            }

            IEnumerable<double> dataToEvaluate;
            if (elementsToEvaluateCount < data.Count())
            {
                dataToEvaluate = data.Take(elementsToEvaluateCount);
            }
            else
            {
                dataToEvaluate = data;
            }

            var maximumValue = dataToEvaluate.Max();
            var minimumValue = dataToEvaluate.Min();
            var averageValue = dataToEvaluate.Average();

            this.printer.Print("Minimum Value: ", minimumValue);
            this.printer.Print("Maximum Value: ", maximumValue);
            this.printer.Print("Average Value: ", averageValue);
        }
    }
}
