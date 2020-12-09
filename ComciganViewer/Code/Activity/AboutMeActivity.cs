using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ComciganViewer.Code.Activity
{
    [Activity]
    public class AboutMeActivity : AppCompatActivity
    {
        private AlertDialog.Builder _builder;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutMe);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.aboutme);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            var sendMailButton = FindViewById<Button>(Resource.Id.send_mail_button);
            var goToGitHubButton = FindViewById<Button>(Resource.Id.go_to_github);
            var openRemarksButton = FindViewById<Button>(Resource.Id.open_remark);

            sendMailButton.Click += SendMailButton_Click;
            goToGitHubButton.Click += GoToGitHubButton_Click;
            openRemarksButton.Click += OpenRemarksButton_Click;

            var versionText = FindViewById<TextView>(Resource.Id.versionText);

            versionText.Text = AppInfo.VersionString;
        }

        private void OpenRemarksButton_Click(object sender, EventArgs e)
        {
            _builder = new AlertDialog.Builder(this);
            _builder
                .SetTitle(Resource.String.aboutme_remark_title)
                .SetMessage(Resource.String.aboutme_remark_text)
                .SetNeutralButton(Resource.String.aboutme_remark_ok, delegate { });
            _builder.Create().Show();
        }

        private void GoToGitHubButton_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse(GetString(Resource.String.github_download_adress));
            var intent = new Intent(Intent.ActionView, uri);
            intent.AddFlags(ActivityFlags.NewTask);
            StartActivity(intent);
        }

        private void SendMailButton_Click(object sender, EventArgs e)
        {
            var email = new Intent(Intent.ActionSend);
            email.SetType("plain/text");
            string[] address = { GetString(Resource.String.email_address) };
            email.PutExtra(Intent.ExtraEmail, address);
            email.PutExtra(Intent.ExtraSubject, GetString(Resource.String.email_subject));
            email.PutExtra(Intent.ExtraText, GetString(Resource.String.email_text));
            StartActivity(email);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (Android.Resource.Id.Home == item.ItemId)
            {
                OnBackPressed();

                return true;
            }

            return false;
        }
    }
}
