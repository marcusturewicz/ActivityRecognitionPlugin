using System;
using System.Collections.Generic;

namespace ActivityRecognitionPlugin
{
    public static partial class ActivityRecognition
    {
        public static void Start()
        {
            if (!IsSupported)
                throw new NotImplementedException();

            PlatformStart();
        }

        public static void Stop()
        {
            if (!IsSupported)
                throw new NotImplementedException();

            PlatformStop();
        }

        public static event EventHandler<ActivityEventArgs> ActivityChaned;

        static void OnChanged(object sender, ActivityEventArgs e)
        {
            ActivityChaned?.Invoke(sender, e);
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