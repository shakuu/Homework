
namespace TradeAndTravel
{
    using System;

    public abstract class Location : WorldObject, ILocation
    {
        public LocationType LocationType { get; private set; }

        public Location(string name, string type)
            : base(name)
        {
            foreach (var locType in (LocationType[])Enum.GetValues(typeof(LocationType)))
            {
                if (locType.ToString() == type)
                {
                    this.LocationType = locType;
                }
            }
        }

        public Location(string name, LocationType type)
            : base(name)
        {
            this.LocationType = type;
        }
    }
}
