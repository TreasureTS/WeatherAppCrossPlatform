using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UnderTheWeatherCrossPlatform.Droid.Intro;
using PortableClassLibrary.Helpers;
using CloudSDK.Models;
using Android.Graphics;

namespace UnderTheWeatherCrossPlatform.Droid.UnderTheWeatherActivities
{
    [Activity(Label = "UnderTheWeatherActivity")]
    public class UnderTheWeatherActivity : Activity
    {
        TextView txtDescription;
        TextView txtPlaceOfResidence;
        TextView txtTemp;
        ImageView imgIcon;
        TextView txtMin;
        TextView txtMax;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.underTheWeatherLayout);
            Bitmap bitMapImage = BitmapFactory.DecodeByteArray(AppSingleton.Instance.imageByte, 0, AppSingleton.Instance.imageByte.Length);
            txtDescription = FindViewById(Resource.Id.txtDescription) as TextView;
            txtPlaceOfResidence = FindViewById(Resource.Id.txtPlaceOfResidence) as TextView;
            imgIcon = FindViewById(Resource.Id.imgIcon) as ImageView;
            txtTemp = FindViewById(Resource.Id.txtTemp) as TextView;
            txtMin = FindViewById(Resource.Id.txtMin) as TextView;
            txtMax = FindViewById(Resource.Id.txtMax) as TextView;


            txtDescription.Text = AppSingleton.Instance.weatherDescription.ToString();
            imgIcon.SetImageBitmap(bitMapImage);
            txtPlaceOfResidence.Text = AppSingleton.Instance.nameOfPlace + " " + DateTime.Now.ToString("dd , yyyy");
            txtTemp.Text = TemperatureConverter.convertToCelcius(AppSingleton.Instance.temperature).ToString() + "°";
            txtMax.Text =" max " + TemperatureConverter.convertToCelcius(AppSingleton.Instance.maximumTemperature).ToString() + "°";
            txtMin.Text = " min " + TemperatureConverter.convertToCelcius(AppSingleton.Instance.minimumTemparature).ToString() + "°";
        }
    }
}