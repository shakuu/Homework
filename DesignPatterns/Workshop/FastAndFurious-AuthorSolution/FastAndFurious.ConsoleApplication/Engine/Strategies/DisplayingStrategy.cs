using System;
using System.Collections.Generic;
using System.Linq;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class DisplayingStrategy : Strategy
    {
        protected override bool CanExecute(IList<string> commandParameters)
        {
            return GlobalConstants.DisplayingStrategyCommand == commandParameters[0];
        }

        protected override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var count = int.Parse(commandParameters[2]);
            var raceTrackId = int.Parse(commandParameters[6]);
            var raceTrack = engineCollections.RaceTracks.GetById(raceTrackId);
            var results = raceTrack.FinishedRacesResults
                .SelectMany(x => x)
                .OrderBy(x => x.TotalSeconds)
                .Take(count);

            engineCollections.IoProvider.WriteLine(
                results != null && results.Count() > 0 ?
                String.Format(GlobalConstants.DisplayBestNTimesEverMessage, count, raceTrack.TrackName) :
                String.Format(GlobalConstants.NoRacesYetMessage, raceTrack.TrackName));

            foreach (var result in results)
            {
                engineCollections.IoProvider.WriteLine(result.ToString());
            }
        }
    }
}
