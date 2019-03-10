using System;
using System.Collections.Generic;

namespace Plugin.ActivityRecognition
{
    public class ActivityEventArgs : EventArgs
    {
        public IDictionary<ActivityType, Confidence> Activities;
        public DateTime StartDate { get;  }

        public ActivityEventArgs(IDictionary<ActivityType, Confidence> activities, DateTime date)
        {
            Activities = activities;
            StartDate = date;
        }
    }
}
