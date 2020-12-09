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
        private DrawerLayout _view = null;
        private NavigationView _navigationView = null;

        protected Toolbar _toolbar = null;

        private readonly int _navMenuItem;
        private readonly int _titleName;

        public BaseActivity(int navMenuItem, int titleName)
        {
            _navMenuItem = navMenuItem;
            _titleName = titleName;
        }

        public override void SetContentView(int layoutResID)
        {
            _view = (DrawerLayout)LayoutInflater.Inflate(Resource.Layout.BaseActivity, null);
            var activityContainer = _view.FindViewById<FrameLayout>(Resource.Id.activity_content);
            LayoutInflater.Inflate(layoutResID, activityContainer, true);
            base.SetContentView(_view);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);
            SupportActionBar.SetTitle(_titleName);

            var drawerToggle = new ActionBarDrawerToggle
                (this, _view, _toolbar, Resource.String.nav_open, Resource.String.nav_close);
            _view.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            _navigationView = FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var menuItem = e.MenuItem;

            if (!menuItem.IsChecked)
            {
                menuItem.SetChecked(true);
            }

            _view.CloseDrawers();

            switch (menuItem.ItemId)
            {
                case Resource.Id.nav_timetable_student:
                    if (_navMenuItem != Resource.Id.nav_timetable_student)
                    {
                        StartActivity(typeof(StudentTimetableActivity));
                        Finish();
                    }
                    break;

                case Resource.Id.nav_timetable_teacher:
                    if (_navMenuItem != Resource.Id.nav_timetable_teacher)
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
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var id = 0;
            switch (_navMenuItem)
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

            _navigationView.SetCheckedItem(id);
            return true;
        }
    }
}
