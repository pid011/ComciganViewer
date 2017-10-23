using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ComciganViewer.Activities
{
    [Activity]
    public class AboutMeActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutMe);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.aboutme_title);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            Button sendMailButton = FindViewById<Button>(Resource.Id.send_mail_button);
            Button goToGitHubButton = FindViewById<Button>(Resource.Id.go_to_github);

            sendMailButton.Click += SendMailButton_Click;
            goToGitHubButton.Click += GoToGitHubButton_Click;
        }

        private void GoToGitHubButton_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse(GetString(Resource.String.github_adress));
            var intent = new Intent(Intent.ActionView, uri);
            intent.AddFlags(ActivityFlags.NewTask);
            StartActivity(intent);
        }

        private void SendMailButton_Click(object sender, EventArgs e)
        {
            Intent email = new Intent(Intent.ActionSend);
            email.SetType("plain/text");
            String[] address = { GetString(Resource.String.email_address) };
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