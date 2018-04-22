using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace ComciganViewer.Code
{
    public class WebViewUtil
    {
        public static WebView ConfigWebView_Timetable(string adress, WebView webView)
        {
            webView.SetWebViewClient(new ComciganWebViewClient());
            webView.LoadUrl(adress);
            webView.Settings.JavaScriptEnabled = true;
            webView.SetScrollContainer(false);
            webView.Settings.DomStorageEnabled = true;
            //webView.Settings.BuiltInZoomControls = true;
            //webView.Settings.SetSupportZoom(true);
            
            return webView;
        }
    }
}