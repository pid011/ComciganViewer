using Android.Webkit;

namespace Timetable
{
	public class ComciganWebViewClient : WebViewClient
	{
		public override bool ShouldOverrideUrlLoading(WebView view, string url)
		{
			view.LoadUrl(url);
			return true;
		}
	}
}