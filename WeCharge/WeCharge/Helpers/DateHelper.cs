using System;
namespace WeCharge.Helpers
{
    public class DateHelper
    {
        public string TodayDate { get; private set; }
        public string OneWeekAgo { get; private set; }

        public DateHelper()
        {
            // Get today's date in ISO 8601 format
            TodayDate = DateTime.Now.ToString("yyyy-MM-dd");

            // Calculate the date one week ago
            DateTime oneWeekAgoDate = DateTime.Now - TimeSpan.FromDays(7);
            OneWeekAgo = oneWeekAgoDate.ToString("yyyy-MM-dd");
        }
    }

}

