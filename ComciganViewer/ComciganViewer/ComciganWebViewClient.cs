using Android.Webkit;
using System;

namespace ComciganViewer
{
    public class ComciganWebViewClient : WebViewClient
    {
        [Obsolete]
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
}