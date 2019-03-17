using System;
using System.Collections.Generic;

namespace Plugin.ActivityRecognition
{
    public static partial class ActivityRecognition
    {
        static event EventHandler<ActivityEventArgs> ActivityChanedInternal;

        static void OnChanged(ActivityEventArgs e)
        {
            ActivityChanedInternal?.Invoke(this, e);
        }
    }

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