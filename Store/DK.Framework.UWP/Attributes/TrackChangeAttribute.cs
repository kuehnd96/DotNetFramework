using System;

namespace DK.Framework.UWP.Attributes
{
    /// <summary>
    /// Assign to a property on a <see cref="Bindable"/> instance to enable change tracking.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TrackChangeAttribute : Attribute
    {
        // NOTE: Left blank intentionally as this is a just an indicator
        //  This could become the foundation for undo functionality and/or change tracking history
    }
}
