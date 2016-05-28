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
	[Activity(Label = "Timetable",
		Icon = "@drawable/icon",
		Theme = "@style/TimetableTheme")]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			Android.Support.V7.Widget.Toolbar toolbar = 
				FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

			SetSupportActionBar(toolbar);
			SupportActionBar.Title = GetString(Resource.String.Timetable);
			SupportActionBar.SetDisplayShowTitleEnabled(false);
			SupportActionBar.SetDisplayShowHomeEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);

			
			

			WebView web_view = FindViewById<WebView>(Resource.Id.main_webview);
			web_view.SetWebViewClient(new ComciganWebViewClient());
			web_view.LoadUrl("http://112.186.146.96:4080/");
			web_view.Settings.JavaScriptEnabled = true;
			web_view.SetScrollContainer(true);
			web_view.Settings.DomStorageEnabled = true;
			
		}
		public override bool OnPrepareOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
			return base.OnPrepareOptionsMenu(menu);
		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch(item.ItemId)
			{
				case (Resource.Id.action_settings):
					break;

				case (Resource.Id.action_creator):
					break;
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}

