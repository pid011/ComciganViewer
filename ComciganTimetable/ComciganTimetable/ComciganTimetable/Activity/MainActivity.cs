using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Java.Lang;
using toolbar = Android.Support.V7.Widget.Toolbar;

namespace Timetable
{
	[Activity(Label = "Timetable",
		Icon = "@drawable/icon",
		Theme = "@style/TimetableTheme")]
	public class MainActivity : AppCompatActivity
	{
		private WebView web_view;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			var toolbar = FindViewById<toolbar>(Resource.Id.toolbar);

			SetSupportActionBar(toolbar);
			SupportActionBar.Title = GetString(Resource.String.Timetable);
			SupportActionBar.SetDisplayShowHomeEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);

			web_view = FindViewById<WebView>(Resource.Id.main_webview);
			web_view.SetWebViewClient(new ComciganWebViewClient());


			CookieManager cookieManager = CookieManager.Instance;
			if(Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
			{
				//Passing in the WebView instance and true to accept
				cookieManager.SetAcceptThirdPartyCookies(web_view, true);
			}
			web_view.LoadUrl("http://m.naver.com");
			web_view.Settings.JavaScriptEnabled = true;
			web_view.SetScrollContainer(true);
			web_view.Settings.DomStorageEnabled = true;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);
			return true;
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