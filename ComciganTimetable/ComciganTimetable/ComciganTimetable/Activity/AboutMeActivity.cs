using System;
using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Views.InputMethods;
using Android.Content;
using Android.Views;
using Android.Webkit;
using Timetable;

namespace Timetable
{
	[Activity(Label = "AboutMeActivity",
		Theme = "@style/TimetableTheme")]
	public class AboutMeActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.aboutDeveloper);
			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			SupportActionBar.SetTitle(Resource.String.creator);
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
			if(Android.Resource.Id.Home != item.ItemId)
				return false;

			OnBackPressed();
			return true;
		}
	}
}