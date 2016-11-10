using System;
using System.Collections.Generic;
using System.Linq;

using FastAndFurious.ConsoleApplication.Engine.Contracts;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Extensions;

namespace FastAndFurious.ConsoleApplication.Engine.Strategies
{
    public class RunningStrategy : Strategy
    {
        protected override bool CanExecute(IList<string> commandParameters)
        {
            return GlobalConstants.RunningStrategyCommand == commandParameters[0];
        }

        protected override void ExecuteCommand(IList<string> commandParameters, IEngineCollections engineCollections)
        {
            var trackId = int.Parse(commandParameters[2]);
            var track = engineCollections.RaceTracks.GetById(trackId);
            engineCollections.IoProvider.WriteLine(String.Format(GlobalConstants.PerformingRaceOnTrackMessage, track.TrackName, track.Participants.Count()));
            track.RunRace();
        }
    }
}
