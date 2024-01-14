using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfExplorer.Support.Local.Models;

public partial class FolderInfo : FileInofBasecs
{
    [ObservableProperty]
    private bool _isFolderExpanded;
    [ObservableProperty]
    private bool _isFolderSelected;

    public ObservableCollection<FolderInfo> Children { get; set; }
}
