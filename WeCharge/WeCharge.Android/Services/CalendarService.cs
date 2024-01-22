using System;
using Xamarin.Forms;
using Android.Content;
using static Android.Util.EventLogTags;
using Android.Provider;
using Android.App;
using WeCharge.CustomControls;
using WeCharge.Droid.Services;

[assembly: Dependency(typeof(CalendarService))]

namespace WeCharge.Droid.Services
{
    public class CalendarService : ICalendarService
    {


        public bool AddEvent(string title, string details, DateTime startDate, DateTime endDate, string location)
        {
            long startMillis = ConvertToUnixTimestamp(startDate);
            long endMillis = ConvertToUnixTimestamp(endDate);
            Intent intent = new Intent(Intent.ActionInsert);
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, title);
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, details);
            intent.PutExtra(CalendarContract.ExtraEventBeginTime, startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            intent.PutExtra(CalendarContract.ExtraEventEndTime, endDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"));
            intent.PutExtra(CalendarContract.ExtraEventBeginTime, startMillis);
            intent.PutExtra(CalendarContract.ExtraEventEndTime, endMillis);
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, TimeZoneInfo.Local.Id);
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventLocation, location); // Add location
            intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventLocation, location);
            intent.SetData(CalendarContract.Events.ContentUri);
            ((Activity)Forms.Context).StartActivity(intent);
            return true;
        }
        private long ConvertToUnixTimestamp(DateTime date)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = date.ToUniversalTime() - unixEpoch;
            return (long)timeSpan.TotalMilliseconds;
        }
    }
}
