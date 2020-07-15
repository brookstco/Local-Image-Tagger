using System;
using System.Windows.Input;

namespace LocalImageTagger.ViewModels
{
    class FirstTimePopUpViewModel
    {
        //
        //These cannot be databound for some reason. Couldn't find any info online about it, so they are here for if I figure it out
        public Uri HyperlinkWiki { get; private set; } = new Uri("https://github.com/brookstco/Local-Image-Tagger");
        public Uri HyperlinkReport { get; private set; } = new Uri("https://github.com/brookstco/Local-Image-Tagger/issues");

        //public Naviga

        //public HyperlinkCommand<Uri> HyperlinkRequest { get; private set; }

        public FirstTimePopUpViewModel()
        {
            //HyperlinkRequest = new HyperlinkCommand.Hyperlink_RequestNavigate();
        }

    }
}
