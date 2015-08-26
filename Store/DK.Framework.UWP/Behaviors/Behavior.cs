using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;

namespace DK.Framework.UWP.Behaviors
{
    public abstract class Behavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; set; }

        public virtual void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
        }

        public virtual void Detach()
        {
        }
    }

    // Summary:
    //     Encapsulates state information and zero or more ICommands into an attachable
    //     object.
    //
    // Type parameters:
    //   AssociatedType:
    //     The type the System.Windows.Interactivity.Behavior<T> can be attached to.
    //
    // Remarks:
    //     Behavior is the base class for providing attachable state and commands to
    //     an object.  The types the Behavior can be attached to can be controlled by
    //     the generic parameter.  Override OnAttached() and OnDetaching() methods to
    //     hook and unhook any necessary handlers from the AssociatedObject.
    public abstract class Behavior<AssociatedType> : Behavior where AssociatedType : DependencyObject
    {
        [System.ComponentModel.EditorBrowsable(
           System.ComponentModel.EditorBrowsableState.Never)]

        // Summary:
        //     Gets the object to which this System.Windows.Interactivity.Behavior<T> is
        //     attached.
        public new AssociatedType AssociatedObject { get; set; }

        public override void Attach(DependencyObject associatedObject)
        {
            base.Attach(associatedObject);
            this.AssociatedObject = (AssociatedType)associatedObject;
            OnAttached();
        }

        public override void Detach()
        {
            base.Detach();
            OnDetaching();
        }

        protected virtual void OnAttached()
        {
        }

        protected virtual void OnDetaching()
        {
        }
    }
}
