using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
<<<<<<< HEAD
using Java.Lang;
using toolbar = Android.Support.V7.Widget.Toolbar;
=======
using Timetable;
>>>>>>> refs/remotes/origin/master

namespace Timetable
{
	[Activity(Label = "Timetable",
		Icon = "@drawable/icon",
		Theme = "@style/TimetableTheme")]
	public class MainActivity : AppCompatActivity
	{
<<<<<<< HEAD
		private WebView web_view;

=======
>>>>>>> refs/remotes/origin/master
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

<<<<<<< HEAD
			var toolbar = FindViewById<toolbar>(Resource.Id.toolbar);
=======
			Android.Support.V7.Widget.Toolbar toolbar = 
				FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
>>>>>>> refs/remotes/origin/master

			SetSupportActionBar(toolbar);
			SupportActionBar.Title = GetString(Resource.String.Timetable);
			SupportActionBar.SetDisplayShowHomeEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);

			
			

<<<<<<< HEAD

			CookieManager cookieManager = CookieManager.Instance;
			if(Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
			{
				//Passing in the WebView instance and true to accept
				cookieManager.SetAcceptThirdPartyCookies(web_view, true);
			}
			web_view.LoadUrl("http://m.naver.com");
=======
			WebView web_view = FindViewById<WebView>(Resource.Id.main_webview);
			web_view.SetWebViewClient(new ComciganWebViewClient());
			web_view.LoadUrl("http://112.186.146.96:4080/");
>>>>>>> refs/remotes/origin/master
			web_view.Settings.JavaScriptEnabled = true;
			web_view.SetScrollContainer(true);
			web_view.Settings.DomStorageEnabled = true;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch(item.ItemId)
			{
				case (Resource.Id.action_creator):
					StartActivity(typeof(AboutMeActivity));
					break;
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}