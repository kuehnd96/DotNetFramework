using DK.Framework.UWP;

namespace DK.Framework.Store.WinPhone8.Tests.ViewModels
{
    /// <summary>
    /// View model for unit testing.
    /// </summary>
    public class TestViewModel : Bindable
    {
        string _label;
        int _count;

        public string Label
        {
            get { return _label; }
            set
            {
                if (value != _label)
                {
                    _label = value;
                    OnPropertyChanged("Label");
                }
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value != _count)
                {
                    _count = value;
                    OnPropertyChanged("Count");
                }
            }
        }
    }
}
