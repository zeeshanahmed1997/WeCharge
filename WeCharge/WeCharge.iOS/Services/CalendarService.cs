using System;
using System.Runtime.CompilerServices;
using EventKit;
using Foundation;
using WeCharge.iOS;
using WeCharge.CustomControls;
using WeCharge.iOS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(CalendarService))]

namespace WeCharge.iOS.Services
{
    public class CalendarService : ICalendarService
    {
        public bool AddEvent(string title, string details, DateTime startDate, DateTime endDate, string location)
        {
            //ObjCRuntime.Class.ThrowOnInitFailure = false;
            bool IsStoreEvent = true;
            ObjCRuntime.Class.ThrowOnInitFailure = true;
            EKEventStore eventStore = new EKEventStore();
            eventStore.RequestAccess(EKEntityType.Event, (granted, error) =>
            {
                if (granted)
                {
                    EKEvent newEvent = EKEvent.FromStore(eventStore);
                    newEvent.Title = title;
                    newEvent.Notes = details;
                    newEvent.StartDate = startDate.ToNSDate();
                    newEvent.EndDate = endDate.ToNSDate();
                    newEvent.Calendar = eventStore.DefaultCalendarForNewEvents;

                    NSError err;
                    //eventStore.SaveEvent(newEvent, EKSpan.ThisEvent, out err);
                    IsStoreEvent = eventStore.SaveEvent(newEvent, EKSpan.ThisEvent, out err);
                    if (err == null)
                    {
                        IsStoreEvent = true;
                    }
                    else
                    {
                        IsStoreEvent = false;
                    }
                }
            });
            return IsStoreEvent;
        }


    }
}
