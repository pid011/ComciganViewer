using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ComciganViewer.Code.Activity
{
    [Activity(MainLauncher = true)]
    public class StudentTimetableActivity : BaseActivity
    {
        public StudentTimetableActivity() 
            : base(Resource.Id.nav_timetable_student, Resource.String.timetable_student)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Webview);

            WebViewUtil.ConfigWebView_Timetable
                (GetString(Resource.String.comcigan_student_adress), 
                FindViewById<WebView>(Resource.Id.webview));
        }
    }
}