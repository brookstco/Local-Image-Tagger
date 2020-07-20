

using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace LocalImageTagger
{
    /// <summary>
    /// Opens <see cref="Hyperlink.NavigateUri"/> in a default system browser
    /// Gotten from stackexchange "https://stackoverflow.com/questions/10238694/example-using-hyperlink-in-wpf/10238715"
    /// </summary>
    public class HyperlinkExternal : Hyperlink
    {
        public HyperlinkExternal()
        {
            RequestNavigate += OnRequestNavigate;
        }

        private void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
