using System;

namespace Plugin.ActivityRecognition
{
    public static partial class ActivityRecognition
    {
        internal static bool IsSupported
            => throw new NotImplementedInReferenceAssemblyException();

        static void Start()
            => throw new NotImplementedInReferenceAssemblyException();

        static void Stop()
            => throw new NotImplementedInReferenceAssemblyException();
    }

    public class NotImplementedInReferenceAssemblyException : Exception
    {
        
    }
}