using Jamesnet.Wpf.Mvvm;
using WpfExplorer.Support.Local.Helpers;

namespace WpfExplorer.Forms.Local.ViewModels;

public class ExplorerViewModel : ObservableBase
{
    public string DownloadDirectory { get; set; }
    public string DocumentsDirectory { get; set; }
    public string PicturesDirectory { get; set; }

    public ExplorerViewModel(DirectoryManager directoryManager) 
    {
        DownloadDirectory = directoryManager.DownloadDirectory;
        DocumentsDirectory = directoryManager.DocumentsDirectory;
        PicturesDirectory = directoryManager.PicturesDirectory;
    }
}
