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

namespace ComciganTimetable
{
	[Activity(Label = "StartActivity", 
		Icon = "@drawable/icon",
		Theme = "@style/MyTheme")]
	public class StartActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Start);
		}
	}
}