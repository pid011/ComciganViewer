using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Support.V7.App;
using System.Threading;
using System.Threading.Tasks;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace Timetable
{
	[Activity(Theme = "@style/TimetableTheme.Splash",
		MainLauncher = true,
		NoHistory = true)]
	public class SplashActivity : AppCompatActivity
	{
		private AlertDialog.Builder builder;
		private bool isOnline = false;

		public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
		{
			base.OnCreate(savedInstanceState, persistentState);
			ActionBar.Title = "컴시간알리미 뷰어";
		}

		protected override void OnResume()
		{
			base.OnResume();

			Task startupWork = new Task(() =>
			{
				Thread.Sleep(1000);
			});

			startupWork.ContinueWith(t =>
			{
				CheckInternet();
				if(isOnline)
				{
					StartActivity(new Intent(Application.Context, typeof(MainActivity)));
				}
			}, TaskScheduler.FromCurrentSynchronizationContext());

			startupWork.Start();
		}

		private void CheckInternet()
		{
			ConnectivityManager manager = (ConnectivityManager)GetSystemService(ConnectivityService);

			builder = new AlertDialog.Builder(this);

			NetworkInfo activeConnection = manager.ActiveNetworkInfo;
			isOnline = (activeConnection != null) && activeConnection.IsConnected;
			if(!isOnline)
			{
				builder
					.SetTitle(Resource.String.NoOnline_title)
					.SetMessage(Resource.String.NoOnline_msg)
					.SetPositiveButton(Resource.String.NoOnline_ConnectWiFi, delegate
					{
						StartActivity(typeof(SplashActivity));
						StartActivityForResult(new Intent(Android.Provider.Settings.ActionWifiSettings), 1);
					})
					.SetNegativeButton(Resource.String.NoOnline_ConnectDataRoaming, delegate
					{
						StartActivity(typeof(SplashActivity));
						StartActivityForResult(new Intent(Android.Provider.Settings.ActionDataRoamingSettings), 1);
					});
				builder.Create().Show();
			}
		}
	}
}