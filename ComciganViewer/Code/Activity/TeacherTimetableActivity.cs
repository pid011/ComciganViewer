using Android.App;
using Android.OS;
using Android.Webkit;

namespace ComciganViewer.Code.Activity
{
    [Activity]
    public class TeacherTimetableActivity : BaseActivity
    {
        public TeacherTimetableActivity()
            : base(Resource.Id.nav_timetable_teacher, Resource.String.timetable_teacher)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Webview);

            var webview = FindViewById<WebView>(Resource.Id.webview);

            WebViewUtil.ConfigWebView_Timetable(GetString(Resource.String.comcigan_teacher_adress), webview);
        }
    }
}
