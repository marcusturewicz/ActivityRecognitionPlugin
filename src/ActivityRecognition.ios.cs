using System;
using Foundation;
using CoreMotion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plugin.ActivityRecognition
{
    public static partial class Vibration
    {
        private internal static bool IsSupported => true;

        private CMMotionActivityManager _manager = new CMMotionActivityManager();
        private IDictionary<ActivityType, Confidence> _currentActivities;

        public event ActivityEventHandler ActivityEvent;

        // Invoke the Changed event; called whenever list changes
        private void OnChanged(ActivityEventArgs e)
        {
            ActivityEvent?.Invoke(this, e);
        }

        private void OnCMMotionActivity(CMMotionActivity activity)
        {
            // Convert CMMotionActivity to cross type
            var activityTypes = GetActivities(activity);
            OnChanged(new ActivityEventArgs(activityTypes, activity.StartDate.ToDateTime()));
        }

        private IDictionary<ActivityType, Confidence> GetActivities(CMMotionActivity activity)
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

        private Confidence GetConfidence(CMMotionActivityConfidence confidence)
        {
            if (confidence == CMMotionActivityConfidence.Low)
                return Confidence.Low;
            if (confidence == CMMotionActivityConfidence.Medium)
                return Confidence.Medium;
            return Confidence.High;
        }

        public static void Start()
        {
            _manager.StartActivityUpdates(new NSOperationQueue(), OnCMMotionActivity);
        }

        public static void Stop() 
        {
            _manager.StopActivityUpdates();
        }
    }
}