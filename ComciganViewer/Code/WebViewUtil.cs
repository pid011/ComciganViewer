using Android.Webkit;

namespace ComciganViewer.Code
{
    public class WebViewUtil
    {
        public static WebView ConfigWebView_Timetable(string adress, WebView webView)
        {
            webView.SetWebViewClient(new ComciganWebViewClient());
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.DomStorageEnabled = true;
            webView.Settings.LoadWithOverviewMode = false;
            webView.HorizontalScrollBarEnabled = false;
            webView.VerticalScrollBarEnabled = false;
            webView.Settings.SetSupportZoom(true);
            webView.Settings.BuiltInZoomControls = true;

            webView.LoadUrl(adress);

            return webView;
        }
    }
}
