using CoreLocation;
using Foundation;
using PortableClassLibrary.Controllers;
using PortableClassLibrary.Helpers;
using System;
using System.Threading.Tasks;
using UIKit;
using UnderTheWeatherCrossPlatform.iOS.Helper;
namespace UnderTheWeatherCrossPlatform.iOS
{
    public partial class LandingScreenController : UIViewController
    {
        public static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }
        public static LocationManager manager;
        UIViewController weatherViewControllerObj;
        public static UIImage images;
        private string TAG = "LandingScreenController";
        public LandingScreenController (IntPtr handle) : base (handle)
        {
            manager = new LocationManager();
            manager.startLocationUpdates();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            weatherViewControllerObj = Storyboard.InstantiateViewController("weatherViewController") as UIViewController;
            btnStart.TouchUpInside += BtnStart_TouchUpInside;
        }

        private async void BtnStart_TouchUpInside(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStart.SetTitleColor(UIColor.DarkGray, UIControlState.Disabled);
            await WeatherController.setupWeatherApplication(AppSingleton.Instance.latitude, AppSingleton.Instance.longetude);
            btnStart.Enabled = true;
            btnStart.BackgroundColor = UIColor.FromRGB(27, 79, 114);
            NavigationController.PushViewController(weatherViewControllerObj, true);
        }
       
    }
}