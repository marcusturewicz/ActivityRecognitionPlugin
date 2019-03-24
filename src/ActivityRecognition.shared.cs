using System;
using System.Collections.Generic;

namespace Plugin.ActivityRecognition
{
    public static partial class ActivityRecognition
    {
        static event EventHandler<ActivityEventArgs> ActivityChanedInternal;

        static void OnChanged(object sender, ActivityEventArgs e)
        {
            ActivityChanedInternal?.Invoke(sender, e);
        }
    }

    public class ActivityEventArgs : EventArgs
    {
        public IDictionary<ActivityType, Confidence> Activities;

        public ActivityEventArgs(IDictionary<ActivityType, Confidence> activities)
        {
            Activities = activities;
        }
    }
}