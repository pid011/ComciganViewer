using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ComciganViewer.Activities
{
    [Activity]
    public class AboutMeActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutMe);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.about_me_title);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            Button button = FindViewById<Button>(Resource.Id.openGithub);

            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://github.com/pid011/Comcigan-App");
            var intent = new Intent(Intent.ActionView, uri);
            intent.AddFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (Android.Resource.Id.Home == item.ItemId)
            {
                OnBackPressed();

                return true;
            }

            return false;
        }
    }
}