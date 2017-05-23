// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UnderTheWeatherCrossPlatform.iOS
{
    [Register ("weatherViewController")]
    partial class weatherViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgWeatherIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMax { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPlaceAndDate { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTemp { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgWeatherIcon != null) {
                imgWeatherIcon.Dispose ();
                imgWeatherIcon = null;
            }

            if (lblDate != null) {
                lblDate.Dispose ();
                lblDate = null;
            }

            if (lblDescription != null) {
                lblDescription.Dispose ();
                lblDescription = null;
            }

            if (lblMax != null) {
                lblMax.Dispose ();
                lblMax = null;
            }

            if (lblMin != null) {
                lblMin.Dispose ();
                lblMin = null;
            }

            if (lblPlaceAndDate != null) {
                lblPlaceAndDate.Dispose ();
                lblPlaceAndDate = null;
            }

            if (lblTemp != null) {
                lblTemp.Dispose ();
                lblTemp = null;
            }
        }
    }
}