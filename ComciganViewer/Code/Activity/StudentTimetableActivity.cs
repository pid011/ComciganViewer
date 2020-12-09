using Android.App;
using Android.OS;
using Android.Webkit;

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

            var webview = FindViewById<WebView>(Resource.Id.webview);
            WebViewUtil.ConfigWebView_Timetable(GetString(Resource.String.comcigan_student_adress), webview);
        }
    }
}
