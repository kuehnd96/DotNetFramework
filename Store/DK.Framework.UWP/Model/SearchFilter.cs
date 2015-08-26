using System;
using System.Collections.ObjectModel;

namespace DK.Framework.UWP.Model
{
    /// <summary>
    /// A filter for search contracts.
    /// </summary>
    /// <typeparam name="TFiltered">The type of object filtered by this filter.</typeparam>
    public class SearchFilter<TFiltered> : Bindable
    {
        static readonly string DescriptionFormat = "{0} ({1})";
        static readonly string DescriptionPropertyName = "Description";
        
        String _name;
        int _count;
        bool _isActive;
        ObservableCollection<TFiltered> _results;

        /// <summary>
        /// A new populated instance.
        /// </summary>
        /// <param name="name">The name of the filter.</param>
        /// <param name="isActive">Whether the filter is active.</param>
        public SearchFilter(string name, bool isActive = false)
        {
            Name = name;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the name label of this filter.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                OnPropertyChanged(DescriptionPropertyName);
            }
        }

        /// <summary>
        /// Gets or sets the number of items associated with this filter.
        /// </summary>
        public int Count
        {
            get { return _count; }
            set
            {
                SetProperty(ref _count, value);
                OnPropertyChanged(DescriptionPropertyName);
            }
        }

        /// <summary>
        /// Gets or sets whether this filter is active.
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        /// <summary>
        /// Gets or sets items that satisfy this filter.
        /// </summary>
        public ObservableCollection<TFiltered> Results
        {
            get { return _results; }
            set
            {
                SetProperty(ref _results, value);
                Count = value.Count;
            }
        }

        /// <summary>
        /// Gets a description of this filter.
        /// </summary>
        public string Description
        {
            get { return string.Format(DescriptionFormat, Name, Count); }
        }
    }
}
