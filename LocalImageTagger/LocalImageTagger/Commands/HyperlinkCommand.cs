using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Navigation;

namespace LocalImageTagger
{
    class HyperlinkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private RequestNavigateEventArgs uri;

        public HyperlinkCommand(RequestNavigateEventArgs e)
        {
            uri = e;
        }


        /// <summary>
        /// Always returns true, since figuring out how to check if it actually can or not is a pain right now.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Hyperlink_RequestNavigate
        }


        /// <summary>
        /// Open a hyperlink in the default web browser
        /// </summary>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            //Without the UseShellExecute, this breaks.
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
