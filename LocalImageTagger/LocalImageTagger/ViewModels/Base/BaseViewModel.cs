using System.ComponentModel;

namespace LocalImageTagger.ViewModels
{
    /// <summary>
    /// A base viewmodel that that fires property changed. Uses Fody to fire automatically on any changes
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Fires to update the property when a child property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }
}
