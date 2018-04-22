using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ComciganViewer.Code.Activity
{
    public class BaseActivity : AppCompatActivity
    {
        private DrawerLayout view = null;
        private NavigationView navigationView = null;

        protected Toolbar toolbar = null;

        private int navMenuItem;
        private int titleName;

        public BaseActivity(int navMenuItem, int titleName)
        {
            this.navMenuItem = navMenuItem;
            this.titleName = titleName;
        }

        public override void SetContentView(int layoutResID)
        {
            view = (DrawerLayout)LayoutInflater.Inflate(Resource.Layout.BaseActivity, null);
            FrameLayout activityContainer = view.FindViewById<FrameLayout>(Resource.Id.activity_content);
            LayoutInflater.Inflate(layoutResID, activityContainer, true);
            base.SetContentView(view);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(titleName);

            var drawerToggle = new ActionBarDrawerToggle
                (this, view, toolbar, Resource.String.nav_open, Resource.String.nav_close);
            view.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.navigation_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var menuItem = e.MenuItem;

            if (!menuItem.IsChecked)
            {
                menuItem.SetChecked(true);
            }

            switch (menuItem.ItemId)
            {
                case Resource.Id.nav_timetable_student:
                    if (navMenuItem != Resource.Id.nav_timetable_student)
                    {
                        StartActivity(typeof(StudentTimetableActivity));
                        Finish();
                    }
                    break;

                case Resource.Id.nav_timetable_teacher:
                    if (navMenuItem != Resource.Id.nav_timetable_teacher)
                    {
                        StartActivity(typeof(TeacherTimetableActivity));
                        Finish();
                    }
                    break;

                case Resource.Id.nav_aboutMe:
                    StartActivity(typeof(AboutMeActivity));
                    menuItem.SetChecked(false);
                    break;

                default:
                    break;
            }


            view.CloseDrawers();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var id = 0;
            switch (navMenuItem)
            {
                case Resource.Id.nav_timetable_student:
                    id = Resource.Id.nav_timetable_student;
                    break;

                case Resource.Id.nav_timetable_teacher:
                    id = Resource.Id.nav_timetable_teacher;
                    break;

                default:
                    break;
            }

            navigationView.SetCheckedItem(id);
            return true;
        }
    }
}