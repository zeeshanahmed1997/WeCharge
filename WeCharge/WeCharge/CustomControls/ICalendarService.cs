using System;
namespace WeCharge.CustomControls
{
    public interface ICalendarService
    {

        bool AddEvent(string title, string details, DateTime startDate, DateTime endDate, string location);
    }

}

