using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace ComciganViewer
{
    [Activity(Label = "시간표", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            WebView web_view = FindViewById<WebView>(Resource.Id.main_webview);
            web_view.SetWebViewClient(new ComciganWebViewClient());
            web_view.LoadUrl("http://112.186.146.96:4080/");
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetScrollContainer(true);
            web_view.Settings.DomStorageEnabled = true;
        }
    }
}

