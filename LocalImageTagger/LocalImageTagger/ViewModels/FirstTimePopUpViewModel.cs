using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class FirstTimePopUpViewModel
    {
        public string HyperlinkWiki { get; private set; } = "https://github.com/brookstco/Local-Image-Tagger";
        public string HyperlinkReport { get; private set; } = "https://github.com/brookstco/Local-Image-Tagger/issues";

        //public HyperlinkCommand<Uri> HyperlinkRequest { get; private set; }

        public FirstTimePopUpViewModel()
        {
            //HyperlinkRequest = new HyperlinkCommand.Hyperlink_RequestNavigate();
        }

    }
}
