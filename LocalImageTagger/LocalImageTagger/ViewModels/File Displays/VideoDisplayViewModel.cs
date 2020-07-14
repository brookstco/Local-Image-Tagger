using System;

namespace LocalImageTagger.ViewModels
{
    public class VideoDisplayViewModel : BaseViewModel
    {
        public string Stretch { get; set; }

        public Uri VideoUri { get; set; }

        public VideoDisplayViewModel()
        {

        }
    }
}
