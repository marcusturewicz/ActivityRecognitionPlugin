using System;
using Foundation;
using CoreMotion;
using System.Collections.Generic;

namespace Plugin.ActivityRecognition
{
    public static partial class ActivityRecognition
    {
        // TODO: check if actually supported
        internal static bool IsSupported => true;

        static CMMotionActivityManager _manager = new CMMotionActivityManager();

        static void OnCMMotionActivity(CMMotionActivity activity)
        {
            // Convert CMMotionActivity to cross type
            var activityTypes = GetActivities(activity);
            OnChanged(_manager, new ActivityEventArgs(activityTypes));
        }

        static void PlatformStart()
        {
            _manager.StartActivityUpdates(new NSOperationQueue(), OnCMMotionActivity);
        }

        static void PlatformStop()
        {
            _manager.StopActivityUpdates();
        }

        static IDictionary<ActivityType, Confidence> GetActivities(CMMotionActivity activity)
        {
            var activities = new Dictionary<ActivityType, Confidence>();
            var confidence = GetConfidence(activity.Confidence);

            if (activity.Unknown)
                activities.Add(ActivityType.Unknown, confidence);

            if (activity.Stationary)
                activities.Add(ActivityType.Stationary, confidence);

            if (activity.Walking)
                activities.Add(ActivityType.Walking, confidence);

            if (activity.Running)
                activities.Add(ActivityType.Running, confidence);

            if (activity.Cycling)
                activities.Add(ActivityType.Cycling, confidence);

            if (activity.Automotive)
                activities.Add(ActivityType.InVehicle, confidence);

            return activities;
        }

        static Confidence GetConfidence(CMMotionActivityConfidence confidence)
        {
            if (confidence == CMMotionActivityConfidence.Low)
                return Confidence.Low;
            if (confidence == CMMotionActivityConfidence.Medium)
                return Confidence.Medium;
            return Confidence.High;
        }
    }
}