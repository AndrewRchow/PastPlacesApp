using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Plugin.Permissions;
using Android;
using Android.Support.V4.Content;
using Android.Support.V4.App;

namespace PastPlacesApp.Droid
{
    [Activity(Label = "PastPlacesApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
;
            string dbName = "travel_db.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(folderPath, dbName);
            LoadApplication(new App(fullPath));
        }

        protected override void OnStart()

        {

            base.OnStart();
            const string permission = Manifest.Permission.AccessFineLocation;
            if (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Permission Granted");
            }

        }
    }
}