
using System.Windows;

namespace LocalImageTagger.ViewModels
{
    class FirstTimePopUpViewModel : BaseViewModel
    {
        /// <summary>
        /// Closes the window (using MVVM).
        /// </summary>
        public RelayCommand<Window> Close { get; private set; }

        public FirstTimePopUpViewModel()
        {
            Close = new RelayCommand<Window>(CloseHelper.CloseWindow);
        }

    }
}
