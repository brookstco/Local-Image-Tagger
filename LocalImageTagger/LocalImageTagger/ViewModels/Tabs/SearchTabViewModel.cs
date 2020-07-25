
using System.Collections.ObjectModel;

namespace LocalImageTagger.ViewModels
{
    public class SearchTabViewModel : BaseTabViewModel
    {

        public ObservableCollection<FileItem> FileItems { get; set; }

        public SearchTabViewModel()
        {
            TabName = "Search";
        }

    }
}
