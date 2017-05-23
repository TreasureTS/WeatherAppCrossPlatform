using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLocation;
using Foundation;
using UIKit;

namespace UnderTheWeatherCrossPlatform.iOS.Helper
{
    public class LocationUpdateEventArgs
    {
        public CLLocation location
        {
            get;
            set;
        }

        public LocationUpdateEventArgs(CLLocation location)
        {
            this.location = location;
        }
    }
}